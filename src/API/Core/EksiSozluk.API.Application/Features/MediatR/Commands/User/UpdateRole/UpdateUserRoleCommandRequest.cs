using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.UpdateRole
{
    public class UpdateUserRoleCommandRequest : IRequest<UpdateUserRoleCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public UpdateUserRoleCommandRequest()
        {

        }                 

        public UpdateUserRoleCommandRequest(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
