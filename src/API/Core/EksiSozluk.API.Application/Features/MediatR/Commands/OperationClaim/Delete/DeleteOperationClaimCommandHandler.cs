using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Delete
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommandRequest, DeleteOperationClaimCommandResponse>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        public DeleteOperationClaimCommandHandler
            (IOperationClaimRepository operationClaimRepository, IMapper mapper,
             OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<DeleteOperationClaimCommandResponse> Handle(DeleteOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository
                .GetSingleAsync(opc => opc.Id == request.OperationClaimId);

            await _operationClaimBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.OperationClaim>(operationClaim, BusinessConstants.OperationClaim);

            var rows = await _operationClaimRepository.DeleteAsync(operationClaim);

            return new DeleteOperationClaimCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<Guid>
                (data: request.OperationClaimId, title: ServerTitles.Successful, devNote: "", message: ServerMessages.ClaimDeleted)
            };
        }
    }
}
