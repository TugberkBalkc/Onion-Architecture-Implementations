using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.User
{
    public class UserLoginDto : IDto
    {
        public String UserEmail { get; set; }
        public String UserPassword { get; set; }

        public UserLoginDto()
        {

        }

        public UserLoginDto(string userEmail, string userPassword)
        {
            UserEmail = userEmail;
            UserPassword = userPassword;
        }

    }
}
