using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.Update
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public Guid RoleId { get; set; }
        public String RoleName { get; set; }

        public UpdateRoleCommandRequest()
        {

        }

        public UpdateRoleCommandRequest(string roleName)
        {
            RoleName = roleName;
        }
    }
}
