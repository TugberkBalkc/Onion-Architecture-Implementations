using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using EksiSozluk.Shared.Events.User;
using EksiSozluk.Shared.Infrastructure;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserCommandHandler
            (IUserRepository userRepository, IMapper mapper,
             UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules; 
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetSingleAsync(u => u.Id == request.UserId);

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            var emailAddressChangingStatus = await _userBusinessRules.CheckIfEmailChanged(user.Email, request.UserEmail);
           
            _mapper.Map(request, user);

            var rows = await _userRepository.UpdateAsync(user);

            await _userBusinessRules.ActionOnAffectedRowsExists(rows, async () =>
            {
                var userEmailChangedEvent = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = request.UserEmail
                };

                QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.UserExchangeName,
                                                   exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                   queueName: RabbitMQConstants.UserEmailChangedQueueName,
                                                   obj: userEmailChangedEvent);

                user.IsConfirmed = false;
                await _userRepository.UpdateAsync(user);
            });

            var userDto = _mapper.Map<UserDto>(user);

            return new UpdateUserCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<UserDto>
                (data: userDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.UserUpdated)
            };
        }
    }
}
