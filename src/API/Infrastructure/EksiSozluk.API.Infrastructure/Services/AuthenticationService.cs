using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Interfaces.Handlers.Token;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Interfaces.Services;
using EksiSozluk.API.Application.Utilities.Security.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleOperationClaimRepository _roleOperationClaimRepository;

        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationService
            (IRoleRepository roleRepository, IUserRepository userRepository,
            IRoleOperationClaimRepository roleOperationClaimRepository, IMapper mapper,
            ITokenHandler tokenHandler)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _roleOperationClaimRepository = roleOperationClaimRepository;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task<AccessToken> AuthenticateWithRole(String userEmail)
        {
            var user = await _userRepository.GetSingleAsync(u => u.Email.Trim().ToLower() == userEmail.Trim().ToLower());

            var userDto = _mapper.Map<UserDto>(user);

            var role = await _roleRepository.GetSingleAsync(r => r.Id == user.RoleId);

            var roleDto = _mapper.Map<RoleDto>(role);

            return _tokenHandler.CreateAccessTokenWithRole(userDto, roleDto);
        }

        public async Task<AccessToken> AuthenticateWithOperationClaims(String userEmail)
        {
            var user = await _userRepository.GetSingleAsync(u => u.Email.Trim().ToLower() == userEmail.Trim().ToLower());

            var userDto = _mapper.Map<UserDto>(user);

            var userOperationClaims = _roleOperationClaimRepository
                    .GetRolesClaims(user.RoleId)
                    .AsQueryable()
                    .ProjectTo<OperationClaimDto>(_mapper.ConfigurationProvider)
                    .ToList();

            return _tokenHandler.CreateAccessTokenWithOperationClaims(userDto, userOperationClaims);
        }
    }
}
