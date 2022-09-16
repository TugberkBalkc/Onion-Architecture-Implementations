using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Features.MediatR.Common;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetRoleClaims
{
    public class GetRoleClaimQueryResponse : QueryResponseBase<List<OperationClaimDto>>
    {
    }
}
