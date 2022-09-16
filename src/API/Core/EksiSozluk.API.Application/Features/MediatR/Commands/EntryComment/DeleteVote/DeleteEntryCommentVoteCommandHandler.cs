using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using EksiSozluk.Shared.Events.EntryComment;
using EksiSozluk.Shared.Infrastructure;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.DeleteVote
{
    public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommandRequest, DeleteEntryCommentVoteCommandResponse>
    {
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEntryCommentVoteRepository _entryCommentVoteRepository;
        private readonly IMapper _mapper;
        private readonly EntryCommentBusinessRules _entryCommentBusinessRules;

        public DeleteEntryCommentVoteCommandHandler
            (IEntryCommentRepository entryCommentRepository, IUserRepository userRepository,
             IEntryCommentVoteRepository entryCommentVoteRepository, IMapper mapper,
             EntryCommentBusinessRules entryCommentBusinessRules)
        {
            _entryCommentRepository = entryCommentRepository;
            _userRepository = userRepository;
            _entryCommentVoteRepository = entryCommentVoteRepository;
            _mapper = mapper;
            _entryCommentBusinessRules = entryCommentBusinessRules;
        }

        public async Task<DeleteEntryCommentVoteCommandResponse> Handle(DeleteEntryCommentVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var entryComment = await _entryCommentRepository.GetSingleAsync(ec => ec.Id == request.EntryCommentId);

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EntryComment>(entryComment, BusinessConstants.EntryComment);

            var user = await _userRepository.GetSingleAsync(u => u.Id == request.UserId);

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            var entryCommentVote = await _entryCommentVoteRepository
                .GetSingleAsync(ecv => ecv.EntryCommentId == request.EntryCommentId &&
                                ecv.UserId == request.UserId);

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EntryCommentVote>(entryCommentVote, BusinessConstants.EntryCommentVote);

            var deleteEntryCommentVoteEvent = new DeleteEntryCommentVoteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                UserId = request.UserId
            };

            QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.VoteExchangeName,
                                        exchangeType: RabbitMQConstants.DefaultExchangeType,
                                        queueName: RabbitMQConstants.DeleteEntryCommentVoteQueueName,
                                        obj: deleteEntryCommentVoteEvent);
         
            return new DeleteEntryCommentVoteCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryCommentVoteDeleted)
            };
        }
    }
}
