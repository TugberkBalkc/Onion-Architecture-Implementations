using AutoMapper;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Login
{
    public class LoginUserWithRoleCommandHandler : IRequestHandler<LoginUserWithRoleCommandRequest, LoginUserCommandResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly UserBusinessRules _userBusinessRules;

        public LoginUserWithRoleCommandHandler(
            IRoleRepository roleRepository, IUserRepository userRepository, IMapper mapper,
           IAuthenticationService authenticationService, UserBusinessRules userBusinessRules)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserWithRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetSingleAsync(u => u.Email.Trim().ToLower() == request.UserEmail.Trim().ToLower());

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            var hashCompareResult = HashingHelper.VerifyHash(request.UserPassword, user.PasswordHash, user.PasswordSalt);


            if (hashCompareResult is true)
            {
                var role = await _roleRepository.GetSingleAsync(r => r.Id == user.RoleId);

                var roleDto = _mapper.Map<RoleDto>(role);

                var userDto = _mapper.Map<UserDto>(user);

                var accessToken = await _authenticationService.AuthenticateWithRole(userDto.UserEmail);

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
