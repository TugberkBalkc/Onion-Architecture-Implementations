using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Update
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public Guid UserId { get; set; }
        public String UserFirstName { get; set; }
        public String UserLastName { get; set; }
        public String UserEmail { get; set; }
        public String UserContactNumber { get; set; }

        public UpdateUserCommandRequest(string userFirstName, string userLastName, string userEmail, string userContactNumber)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserContactNumber = userContactNumber;
        }

        public UpdateUserCommandRequest()
        {

        }
    }
}
