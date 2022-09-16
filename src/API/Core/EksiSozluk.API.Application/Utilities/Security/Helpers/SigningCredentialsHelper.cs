using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Security.Helpers
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SymmetricSecurityKey symmetricSecurityKey)
        {
            return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        } 
    }
}
