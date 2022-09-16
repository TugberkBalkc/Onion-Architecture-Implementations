using EksiSozluk.API.Application.Utilities.Responses.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetRoleClaims
{
    public class GetRoleClaimsQueryRequest : IRequest<GetRoleClaimQueryResponse>
    {
        public Guid RoleId { get; set; }
    }
}
