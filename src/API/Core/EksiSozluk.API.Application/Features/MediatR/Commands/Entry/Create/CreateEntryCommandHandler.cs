using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Create
{
    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommandRequest, CreateEntryCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly EntryBusinessRules _entryBusinessRules;

        public CreateEntryCommandHandler
            (IEntryRepository entryRepository, IUserRepository userRepository, 
            IMapper mapper, EntryBusinessRules entryBusinessRules)
        {
            _entryRepository = entryRepository;
            _userRepository = userRepository;

            _mapper = mapper;

            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<CreateEntryCommandResponse> Handle(CreateEntryCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository
                .GetSingleAsync(e=>e.UserId == request.UserId &&
                                e.Subject.Trim().ToLower() == request.EntrySubject.Trim().ToLower());

            await _entryBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);

            var mappedEntry = _mapper.Map<Domain.Entities.Entry>(request);

            var rows = await _entryRepository.AddAsync(mappedEntry);

            var entryDto = _mapper.Map<EntryDto>(mappedEntry);

            return new CreateEntryCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<EntryDto>
                (data: entryDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryCreated)
            };
        }
    }
}
