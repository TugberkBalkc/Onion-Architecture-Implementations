using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly UserBusinessRules _userBusinessRules;

        public DeleteUserCommandHandler
            (IUserRepository userRepository, IMapper mapper, 
             UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }


        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetSingleAsync(u => u.Id == request.UserId);

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            var rows = await _userRepository.DeleteAsync(user);

            return new DeleteUserCommandResponse()
            {
                Response = 
                new SuccessfulDataBearerServiceResponse<Guid>
                (data: request.UserId, title: ServerTitles.Successful, devNote: "", message: ServerMessages.UserDeleted)
            };
        }
    }
}
