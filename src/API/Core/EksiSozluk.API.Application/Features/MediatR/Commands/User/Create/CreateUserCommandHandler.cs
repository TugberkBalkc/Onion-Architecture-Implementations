using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Security;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.API.Application.Utilities.Security.Helpers;
using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using EksiSozluk.Shared.Events.User;
using EksiSozluk.Shared.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler
            (IUserRepository userRepository, IMapper mapper,
             UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetSingleAsync(u => u.Email.Trim().ToLower() == request.UserEmail.Trim().ToLower());

            await _userBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            var mappedUser = _mapper.Map<Domain.Entities.User>(request);

            var hashResult = HashingHelper.ComputeHashByKey(request.UserPassword);
            mappedUser.PasswordHash = hashResult.Hash;
            mappedUser.PasswordSalt = hashResult.Salt;

            mappedUser.IsConfirmed = false;

            var rows = await _userRepository.AddAsync(mappedUser);

            await _userBusinessRules.ActionOnAffectedRowsExists(rows, () =>
            {
                var userEmailChangedEvent = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = mappedUser.Email
                };

                QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.UserExchangeName,
                                                   exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                   queueName: RabbitMQConstants.UserEmailChangedQueueName,
                                                   obj: userEmailChangedEvent);
            });

            var userDto = _mapper.Map<UserDto>(mappedUser);

            return new CreateUserCommandResponse()
            {
                Response = 
                new SuccessfulDataBearerServiceResponse<UserDto>
                (data: userDto, title: ServerTitles.Successful, devNote: "", message:ServerMessages.UserRegistered)
            };
        }
    }
}
