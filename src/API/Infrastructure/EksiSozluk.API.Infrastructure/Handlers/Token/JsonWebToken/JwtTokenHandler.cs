using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Interfaces.Handlers.Token;
using EksiSozluk.API.Application.Utilities.Security.Helpers;
using EksiSozluk.API.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Infrastructure.Handlers.Token.JsonWebToken
{
    public class JwtTokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly TokenOptions _tokenOptions;

        private DateTime ExpireDate { get; set; }
        public JwtTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessTokenWithOperationClaims(UserDto userDto, ICollection<OperationClaimDto> operationClaimsDto)
        {
            ExpireDate = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTimeInMinutes);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwtSecurityToken = this.CreateJwtSecurityTokenWithOperationClaims(_tokenOptions, userDto, operationClaimsDto, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            String token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccessToken(token, ExpireDate);
        }

        public AccessToken CreateAccessTokenWithRole(UserDto userDto, RoleDto roleDto)
        {
            ExpireDate = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTimeInMinutes);

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwtSecurityToken = this.CreateJwtSecurityTokenWithRole(_tokenOptions, userDto, roleDto, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            String token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccessToken(token, ExpireDate);
        }

        private JwtSecurityToken CreateJwtSecurityTokenWithOperationClaims(TokenOptions tokenOptions, UserDto userDto, ICollection<OperationClaimDto> operationClaimsDto, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                audience: _tokenOptions.Audience,
                issuer: _tokenOptions.Issuer,
                claims: this.GetConvertedClaimsWithOperationClaim(userDto, operationClaimsDto),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_tokenOptions.ExpirationTimeInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        private JwtSecurityToken CreateJwtSecurityTokenWithRole(TokenOptions tokenOptions, UserDto userDto, RoleDto roleDto, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                audience: _tokenOptions.Audience,
                issuer: _tokenOptions.Issuer,
                claims: this.GetConvertedClaimsWithRole(userDto, roleDto),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_tokenOptions.ExpirationTimeInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        private IEnumerable<Claim> GetConvertedClaimsWithRole(UserDto userDto, RoleDto roleDto)
        {
            var claims = new List<Claim>();

            claims.AddId(userDto.UserId);
            claims.AddFirstName(userDto.UserFirstName);
            claims.AddLastName(userDto.UserLastName);
            claims.AddRole(roleDto.RoleName);

            return claims;
        }

        private IEnumerable<Claim> GetConvertedClaimsWithOperationClaim(UserDto userDto, ICollection<OperationClaimDto> operationClaimDtos)
        {
            var claims = new List<Claim>();

            claims.AddId(userDto.UserId);
            claims.AddFirstName(userDto.UserFirstName);
            claims.AddLastName(userDto.UserLastName);
            claims.AddEmail(userDto.UserEmail);

            var operationClaimNames = operationClaimDtos.Select(opc => opc.OperationClaimName).ToArray();
            claims.AddOperationClaims(operationClaimNames);

            return claims;
        }
    }
}
