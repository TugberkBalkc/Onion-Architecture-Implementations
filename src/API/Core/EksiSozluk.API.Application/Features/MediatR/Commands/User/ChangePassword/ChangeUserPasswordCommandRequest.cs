using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandRequest : IRequest<ChangeUserPasswordCommandResponse>
    {
        public Guid? UserId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public ChangeUserPasswordCommandRequest(Guid? userId, string oldPassword, string newPassword)
        {
            UserId = userId;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
