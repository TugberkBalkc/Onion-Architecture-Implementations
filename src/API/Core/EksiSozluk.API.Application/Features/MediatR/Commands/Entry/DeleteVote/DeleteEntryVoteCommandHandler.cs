using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using EksiSozluk.Shared.Events.Entry;
using EksiSozluk.Shared.Infrastructure;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.DeleteVote
{
    public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommandRequest, DeleteEntryVoteCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEntryVoteRepository _entryVoteRepository;
        private readonly IMapper _mapper;
        private readonly EntryBusinessRules _entryBusinessRules;

        public DeleteEntryVoteCommandHandler(
            IEntryRepository entryRepository, IUserRepository userRepository,
            IEntryVoteRepository entryVoteRepository, IMapper mapper,
            EntryBusinessRules entryBusinessRules)
        {
            _entryRepository = entryRepository;
            _userRepository = userRepository;
            _entryVoteRepository = entryVoteRepository;
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
        }


        public async Task<DeleteEntryVoteCommandResponse> Handle(DeleteEntryVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository.GetSingleAsync(e => e.Id == request.EntryId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);


            var user = await _userRepository.GetSingleAsync(u => u.Id == request.UserId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);


            var entryVote = await _entryVoteRepository
                .GetSingleAsync(ef => ef.EntryId == request.EntryId &&
                                ef.UserId == request.UserId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EntryVote>(entryVote, BusinessConstants.EntryVote);

            var deleteEntryVoteEvent = new DeleteEntryVoteEvent()
            {
                EntryId = request.EntryId,
                UserId = request.UserId,
            };

            QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.VoteExchangeName,
                                        exchangeType: RabbitMQConstants.DefaultExchangeType,
                                        queueName: RabbitMQConstants.DeleteEntryVoteQueueName,
                                        obj: deleteEntryVoteEvent);

            return new DeleteEntryVoteCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryVoteDeleted)
            };
        }
    }
}
