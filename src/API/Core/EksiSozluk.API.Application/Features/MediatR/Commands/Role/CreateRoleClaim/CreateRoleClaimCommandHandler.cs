using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.API.Domain.Entities;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.AddClaim
{
    public class CreateRoleClaimCommandHandler : IRequestHandler<CreateRoleClaimCommandRequest, CreateRoleClaimCommandResponse>
    {
        private readonly IRoleOperationClaimRepository _roleOperationClaimRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly RoleBusinessRules _roleBusinessRules;

        public CreateRoleClaimCommandHandler
            (IRoleRepository roleRepository, IOperationClaimRepository operationClaimRepository, 
            IMapper mapper, IRoleOperationClaimRepository roleOperationClaimRepository,
            RoleBusinessRules roleBusinessRules)
        {
            _roleRepository = roleRepository;
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _roleOperationClaimRepository = roleOperationClaimRepository;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<CreateRoleClaimCommandResponse> Handle(CreateRoleClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetSingleAsync(r => r.Id == request.RoleId);

            await _roleBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Role>(role, BusinessConstants.Role);

            var operationClaim = await _operationClaimRepository.GetSingleAsync(opc => opc.Id == request.OperationClaimId);

            await _roleBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.OperationClaim>(operationClaim, BusinessConstants.OperationClaim);
            
            var roleOperationClaim = await _roleOperationClaimRepository
                .GetSingleAsync(ropc => ropc.RoleId == request.RoleId && 
                                ropc.OperationClaimId == request.OperationClaimId);

            await _roleBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.RoleOperationClaim>(roleOperationClaim, BusinessConstants.RoleOperationClaim);
            
            var mappedRoleOperationClaim = _mapper.Map<RoleOperationClaim>(request);

            var rows = await _roleOperationClaimRepository.AddAsync(mappedRoleOperationClaim);

            var roleOperationClaimDto = _mapper.Map<RoleOperationClaimDto>(mappedRoleOperationClaim);

            return new CreateRoleClaimCommandResponse()
            {
                Response =
                   new SuccessfulDataBearerServiceResponse<RoleOperationClaimDto>
                   (data: roleOperationClaimDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.ClaimAddedInRole)
            };
        }
    }
}
