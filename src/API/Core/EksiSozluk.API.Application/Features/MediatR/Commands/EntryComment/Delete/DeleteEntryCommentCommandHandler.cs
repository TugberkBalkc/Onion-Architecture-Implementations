using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Delete
{
    public class DeleteEntryCommentCommandHandler : IRequestHandler<DeleteEntryCommentCommandRequest, DeleteEntryCommentCommandResponse>
    {
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IMapper _mapper;
        private readonly EntryCommentBusinessRules _entryCommentBusinessRules;

        public DeleteEntryCommentCommandHandler
            (IEntryCommentRepository entryCommentRepository, IMapper mapper,
             EntryCommentBusinessRules entryCommentBusinessRules)
        {
            _entryCommentRepository = entryCommentRepository;
            _mapper = mapper;
            _entryCommentBusinessRules = entryCommentBusinessRules;
        }

        public async Task<DeleteEntryCommentCommandResponse> Handle(DeleteEntryCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var entryComment = await _entryCommentRepository
                .GetSingleAsync(e => e.Id == request.EntryCommentId);

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EntryComment>(entryComment, BusinessConstants.EntryComment);

            var rows = await _entryCommentRepository.DeleteAsync(entryComment);

            return new DeleteEntryCommentCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<Guid>
                (data: entryComment.Id, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryDeleted)
            };
        }
    }
}
