using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Exceptions.BusinessLogic;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.API.Application.Utilities.Security.Helpers;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommandRequest, ChangeUserPasswordCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public ChangeUserPasswordCommandHandler
            (IUserRepository userRepository, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<ChangeUserPasswordCommandResponse> Handle(ChangeUserPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetSingleAsync(u=>u.Id == request.UserId);

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            //var oldPasswordOnRequestHash = HashingHelper.ComputeHashByKey(request.OldPassword);

            var verifyHashes = HashingHelper.VerifyHash(request.OldPassword, user.PasswordHash, user.PasswordSalt);

            await _userBusinessRules.DecideHashesMatched(verifyHashes);
            
            var newPasswordGeneratedHashResult = HashingHelper.ComputeHashByKey(request.NewPassword);

            user.PasswordHash = newPasswordGeneratedHashResult.Hash;
            user.PasswordSalt = newPasswordGeneratedHashResult.Salt;

            var rows = await _userRepository.UpdateAsync(user);

            return new ChangeUserPasswordCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.PasswordChanged)
            };
        }
    }
}
