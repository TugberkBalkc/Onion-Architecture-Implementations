using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.User
{
    public class UserRegisterDto : IDto
    {
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
        public String UserEmail { get; set; }
        public String UserContactNumber { get; set; }
        public String UserPassword { get; set; }

        public UserRegisterDto()
        {

        }

        public UserRegisterDto(string userFirstName, string userLastName, string userEmail, string userContactNumber, string userPassword)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserContactNumber = userContactNumber;
            UserPassword = userPassword;
        }

    }
}
