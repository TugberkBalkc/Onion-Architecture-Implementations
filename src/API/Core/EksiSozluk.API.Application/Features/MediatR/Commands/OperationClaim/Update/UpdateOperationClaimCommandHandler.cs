using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Update
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommandRequest, UpdateOperationClaimCommandResponse>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        public UpdateOperationClaimCommandHandler
            (IOperationClaimRepository operationClaimRepository, IMapper mapper,
             OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<UpdateOperationClaimCommandResponse> Handle(UpdateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository
                .GetSingleAsync(opc => opc.Id == request.OperationClaimId);

            await _operationClaimBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.OperationClaim>(operationClaim, BusinessConstants.OperationClaim);

            _mapper.Map(request, operationClaim);

            var rows = await _operationClaimRepository.UpdateAsync(operationClaim);

            var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);

            return new UpdateOperationClaimCommandResponse()
            {
                Response =new
                SuccessfulDataBearerServiceResponse<OperationClaimDto>
                (data: operationClaimDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.ClaimUpdated)
            };
        }
    }
}
