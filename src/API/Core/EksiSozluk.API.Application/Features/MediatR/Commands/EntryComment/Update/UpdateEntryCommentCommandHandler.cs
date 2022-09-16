using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.EntryComment;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Update
{
    public class UpdateEntryCommentCommandHandler : IRequestHandler<UpdateEntryCommentCommandRequest, UpdateEntryCommentCommandResponse>
    {
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IMapper _mapper;
        private readonly EntryCommentBusinessRules _entryCommentBusinessRules;

        public UpdateEntryCommentCommandHandler
            (IEntryCommentRepository entryCommentRepository, IMapper mapper,
             EntryCommentBusinessRules entryCommentBusinessRules)
        {
            _entryCommentRepository = entryCommentRepository;
            _mapper = mapper;
            _entryCommentBusinessRules = entryCommentBusinessRules;
        }

        public async Task<UpdateEntryCommentCommandResponse> Handle(UpdateEntryCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var entryComment = await _entryCommentRepository
                .GetSingleAsync(e =>e.EntryId == request.EntryId &&
                                e.UserId == request.UserId && 
                                e.Content.Trim().ToLower() == request.EntryCommentContent.Trim().ToLower());

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EntryComment>(entryComment, BusinessConstants.EntryComment);

            _mapper.Map(request, entryComment);

            var rows = await _entryCommentRepository.UpdateAsync(entryComment);

            var entryCommentDto = _mapper.Map<EntryCommentDto>(entryComment);

            return new UpdateEntryCommentCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<EntryCommentDto>
                (data: entryCommentDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryCommentUpdated)
            };
        }
    }
}
