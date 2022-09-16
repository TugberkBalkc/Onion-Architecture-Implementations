using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Authentication
{
    public class TokenOptions
    {
        public String Audience { get; set; }
        public String Issuer { get; set; }
        public String SecurityKey { get; set; }
        public int ExpirationTimeInMinutes { get; set; }

        public TokenOptions()
        {

        }

        public TokenOptions(String audience, String ıssuer, String securityKey, int expirationTimeInMinutes)
        {
            Audience = audience;
            Issuer = ıssuer;
            SecurityKey = securityKey;
            ExpirationTimeInMinutes = expirationTimeInMinutes;
        }
    }
}
