using EksiSozluk.API.Application.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Create
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse> 
    {
        public Guid UserRoleId { get; set; }
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
        public String UserEmail { get; set; }
        public String UserContactNumber { get; set; }
        public String UserPassword { get; set; }

        public CreateUserCommandRequest()
        {

        }

        public CreateUserCommandRequest(string userFirstName, string userLastName, string userEmail, string userContactNumber, string userPassword)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserContactNumber = userContactNumber;
            UserPassword = userPassword;
        }
    }
}
