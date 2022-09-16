using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Authentication
{
    public class AccessToken
    {
        public String Token { get; set; }
        public DateTime ExpireDate { get; set; }

        public AccessToken()
        {

        }

        public AccessToken(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

    }
}
