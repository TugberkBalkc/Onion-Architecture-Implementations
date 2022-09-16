using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Update
{
    public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommandRequest, UpdateEntryCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        private readonly EntryBusinessRules _entryBusinessRules;

        public UpdateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper, EntryBusinessRules entryBusiness)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;

            _entryBusinessRules = entryBusiness;
        }

        public async Task<UpdateEntryCommandResponse> Handle(UpdateEntryCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository.GetSingleAsync(e => e.Id == request.EntryId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);

            _mapper.Map(request, entry);

            var rows = await _entryRepository.UpdateAsync(entry);

            var entryDto = _mapper.Map<EntryDto>(entry);

            return new UpdateEntryCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<EntryDto>
                (data: entryDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryUpdated)
            };
        }
    }
}
