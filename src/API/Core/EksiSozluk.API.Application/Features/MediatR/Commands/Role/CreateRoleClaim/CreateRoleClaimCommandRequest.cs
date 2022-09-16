using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.AddClaim
{
    public class CreateRoleClaimCommandRequest : IRequest<CreateRoleClaimCommandResponse>
    {
        public Guid RoleId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
