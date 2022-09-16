using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Login
{
    public class LoginUserWithRoleCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public String UserEmail { get; set; }
        public String UserPassword { get; set; }

        public LoginUserWithRoleCommandRequest()
        {

        }

        public LoginUserWithRoleCommandRequest(string userEmail, string userPassword)
        {
            UserEmail = userEmail;
            UserPassword = userPassword;
        }
    }
}
