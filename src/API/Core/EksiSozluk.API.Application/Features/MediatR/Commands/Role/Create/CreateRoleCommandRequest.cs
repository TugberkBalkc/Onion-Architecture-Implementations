using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.Create
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public String RoleName { get; set; }
    }
}
