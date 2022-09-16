using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Create
{
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommandRequest, CreateOperationClaimCommandResponse>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public CreateOperationClaimCommandHandler
            (IOperationClaimRepository operationClaimRepository, IMapper mapper,
             OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<CreateOperationClaimCommandResponse> Handle(CreateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository
                .GetSingleAsync(opc => opc.Name.Trim().ToLower() == request.OperationClaimName.Trim().ToLower());

            await _operationClaimBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.OperationClaim>(operationClaim, BusinessConstants.OperationClaim);

            var mappedOperationClaim = _mapper.Map<Domain.Entities.OperationClaim>(request);

            var rows = await _operationClaimRepository.AddAsync(mappedOperationClaim);

            var operationClaimDto = _mapper.Map<OperationClaimDto>(mappedOperationClaim);

            return new CreateOperationClaimCommandResponse()
            {
                Response = new
                SuccessfulDataBearerServiceResponse<OperationClaimDto>
                (data: operationClaimDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.ClaimCreated)
            };
        }
    }
}
