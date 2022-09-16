using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetRoleClaims
{
    public class GetRoleClaimsQueryHandler : IRequestHandler<GetRoleClaimsQueryRequest, GetRoleClaimQueryResponse>
    {
        private readonly IRoleOperationClaimRepository _roleOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetRoleClaimsQueryHandler(IRoleOperationClaimRepository roleOperationClaimRepository, IMapper mapper)
        {
            _roleOperationClaimRepository = roleOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetRoleClaimQueryResponse> Handle(GetRoleClaimsQueryRequest request, CancellationToken cancellationToken)
        {
            var operationClaims = _roleOperationClaimRepository.GetRolesClaims(request.RoleId).AsQueryable();

            var operationClaimDtos = operationClaims
                .ProjectTo<OperationClaimDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new GetRoleClaimQueryResponse()
            {
                Response = new SuccessfulDataBearerServiceResponse<List<OperationClaimDto>>
                (data: operationClaimDtos, title: ServerTitles.Successful, devNote: "", message: ServerMessages.ClaimsRecieved)
            };
        }
    }
}
