using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Exceptions.BusinessLogic;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommandRequest, ConfirmEmailCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailConfirmationRepository _emailConfirmationRepository;
        private readonly UserBusinessRules _userBusinessRules;
        public ConfirmEmailCommandHandler
            (IUserRepository userRepository, IEmailConfirmationRepository emailConfirmationRepository,
             UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _emailConfirmationRepository = emailConfirmationRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<ConfirmEmailCommandResponse> Handle(ConfirmEmailCommandRequest request, CancellationToken cancellationToken)
        {
            var emailConfirmation = await _emailConfirmationRepository.GetSingleAsync(ec => ec.Id == request.EmailConfirmationId);

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EmailConfirmation>(emailConfirmation, BusinessConstants.EmailConfirmation);

            var user = await _userRepository.GetSingleAsync(u => u.Email == emailConfirmation.NewEmail);

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            await _userBusinessRules.CheckIfUserConfirmed(user.IsConfirmed);

            user.IsConfirmed = true;

            var rows = await _userRepository.UpdateAsync(user);

            return new ConfirmEmailCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EmailNowConfirmed)
            };
        }
    }
}
