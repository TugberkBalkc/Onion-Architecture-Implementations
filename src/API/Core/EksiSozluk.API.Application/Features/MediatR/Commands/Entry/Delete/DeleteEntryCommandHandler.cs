using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Delete
{
    public class DeleteEntryCommandHandler : IRequestHandler<DeleteEntryCommandRequest, DeleteEntryCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;
        private readonly EntryBusinessRules _entryBusinessRules;
       
        public DeleteEntryCommandHandler
            (IEntryRepository entryRepository, IMapper mapper,
             EntryBusinessRules entryBusinessRules)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<DeleteEntryCommandResponse> Handle(DeleteEntryCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository
                .GetSingleAsync(e=>e.Id == request.EntryId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);

            var rows = await _entryRepository.DeleteAsync(entry);

            return new DeleteEntryCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<Guid>
                (data: request.EntryId, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryDeleted)
            };
        }
    }
}
