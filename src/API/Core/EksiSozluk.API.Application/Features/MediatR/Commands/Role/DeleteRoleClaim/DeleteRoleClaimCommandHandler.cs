using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.RemoveClaim
{
    public class DeleteRoleClaimCommandHandler : IRequestHandler<DeleteRoleClaimCommandRequest, DeleteRoleClaimCommandResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IRoleOperationClaimRepository _roleOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly RoleBusinessRules _roleBusinessRules;

        public DeleteRoleClaimCommandHandler
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

        public async Task<DeleteRoleClaimCommandResponse> Handle(DeleteRoleClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetSingleAsync(r => r.Id == request.RoleId);

            await _roleBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Role>(role, BusinessConstants.Role);

            var operationClaim = await _operationClaimRepository.GetSingleAsync(opc => opc.Id == request.OperationClaimId);

            await _roleBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.OperationClaim>(operationClaim, BusinessConstants.OperationClaim);

            var roleOperationClaim = await _roleOperationClaimRepository
                .GetSingleAsync(ropc => ropc.RoleId == request.RoleId && 
                                ropc.OperationClaimId == request.OperationClaimId);

            await _roleBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.RoleOperationClaim>(roleOperationClaim, BusinessConstants.RoleOperationClaim);

            var rows = await _roleOperationClaimRepository.DeleteAsync(roleOperationClaim);
        
            return new DeleteRoleClaimCommandResponse()
            {
                Response =
                   new SuccessfulDataBearerServiceResponse<Guid>
                   (data: roleOperationClaim.Id, title: ServerTitles.Successful, devNote: "", message: ServerMessages.ClaimRemovedInRole)
            };
        }
    }
}
