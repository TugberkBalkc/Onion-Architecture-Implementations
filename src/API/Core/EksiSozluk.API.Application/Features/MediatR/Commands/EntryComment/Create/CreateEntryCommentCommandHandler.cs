using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.EntryComment;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Create
{
    public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommandRequest, CreateEntryCommentCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IMapper _mapper;
        private readonly EntryCommentBusinessRules _entryCommentBusinessRules;

        public CreateEntryCommentCommandHandler(
            IEntryRepository entryRepository, IUserRepository userRepository,
            IEntryCommentRepository entryCommentRepository, IMapper mapper,
            EntryCommentBusinessRules entryCommentBusinessRules)
        {
            _entryRepository = entryRepository;
            _userRepository = userRepository;
            _entryCommentRepository = entryCommentRepository;
            _mapper = mapper;
            _entryCommentBusinessRules = entryCommentBusinessRules;
        }

        public async Task<CreateEntryCommentCommandResponse> Handle(CreateEntryCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository.GetSingleAsync(e => e.Id == request.EntryId);

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);

            var entryComment = await _entryCommentRepository
                .GetSingleAsync(ec => ec.EntryId == request.EntryId &&
                                      ec.UserId == request.UserId &&
                                      ec.Content.Trim().ToLower() == request.EntryCommentContent.Trim().ToLower());

            await _entryCommentBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.EntryComment>(entryComment, BusinessConstants.EntryComment);

            var mappedEntryComment = _mapper.Map<Domain.Entities.EntryComment>(request);

            var rows = await _entryCommentRepository.AddAsync(mappedEntryComment);

            var entryCommentDto = _mapper.Map<EntryCommentDto>(mappedEntryComment);

            return new CreateEntryCommentCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<EntryCommentDto>
                (data: entryCommentDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryCommentCreated)
            };
        }
    }
}
