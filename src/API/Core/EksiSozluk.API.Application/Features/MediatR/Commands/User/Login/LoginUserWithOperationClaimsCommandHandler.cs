using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Handlers.Token;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Interfaces.Services;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.API.Application.Utilities.Security.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Login
{
    public class LoginUserWithOperationClaimsCommandHandler : IRequestHandler<LoginUserWithOperationClaimsCommandRequest, LoginUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleOperationClaimRepository _roleOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly UserBusinessRules _userBusinessRules;

        public LoginUserWithOperationClaimsCommandHandler(
            IUserRepository userRepository, IMapper mapper,
            ITokenHandler tokenHandler, IRoleOperationClaimRepository roleOperationClaimRepository,
            IAuthenticationService authenticationService, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _roleOperationClaimRepository = roleOperationClaimRepository;
            _authenticationService = authenticationService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserWithOperationClaimsCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetSingleAsync(u => u.Email.Trim().ToLower() == request.UserEmail.Trim().ToLower());

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            var hashCompareResult = HashingHelper
                .VerifyHash(request.UserPassword, user.PasswordHash, user.PasswordSalt);

            if (hashCompareResult is true)
            {
                var operationClaims = _roleOperationClaimRepository
                    .GetRolesClaims(user.RoleId)
                    .AsQueryable()
                    .ProjectTo<OperationClaimDto>(_mapper.ConfigurationProvider)
                    .ToList();

                var userDto = _mapper.Map<UserDto>(user);

                var accessToken = await _authenticationService.AuthenticateWithOperationClaims(userDto.UserEmail);

                return new LoginUserCommandResponse()
                {
                    Response =
                    new SuccessfulDataBearerServiceResponse<AccessToken>
                    (data: accessToken, title: ServerTitles.Successful, devNote: "", message: ServerMessages.UserLoggedIn)
                };
            }
            else
            {
                return new LoginUserCommandResponse()
                {
                    Response =
                    new ErrorDataBearerServiceResponse<AccessToken>
                    (title: ServerTitles.Successful, devNote: "", message: ServerMessages.EmailOrPasswordIsWrong)
                };
            }
        }
    }
}
