using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Interfaces.Handlers.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessTokenWithRole(UserDto userDto, RoleDto roleDto);
        AccessToken CreateAccessTokenWithOperationClaims(UserDto userDto, ICollection<OperationClaimDto> operationClaimsDto);
    }
}
