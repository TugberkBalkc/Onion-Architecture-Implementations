using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Interfaces.Services
{
    public interface IInternalAuthenticationService
    {
        Task<AccessToken> AuthenticateWithRole(String userEmail);
        Task<AccessToken> AuthenticateWithOperationClaims(String userEmail);
    }
}
