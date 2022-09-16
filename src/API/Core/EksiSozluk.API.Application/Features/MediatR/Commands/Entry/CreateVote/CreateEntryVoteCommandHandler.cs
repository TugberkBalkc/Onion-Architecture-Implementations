using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.API.Domain.Entities;
using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using EksiSozluk.Shared.Events.Entry;
using EksiSozluk.Shared.Infrastructure;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommandRequest, CreateEntryVoteCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEntryVoteRepository _entryVoteRepository;
        private readonly IMapper _mapper;
        private readonly EntryBusinessRules _entryBusinessRules;

        public CreateEntryVoteCommandHandler(
            IEntryRepository entryRepository, IEntryVoteRepository entryVoteRepository,
            IUserRepository userRepository, IMapper mapper,
            EntryBusinessRules entryBusinessRules)
        {
            _entryRepository = entryRepository;
            _entryVoteRepository = entryVoteRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<CreateEntryVoteCommandResponse> Handle(CreateEntryVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository.GetSingleAsync(e => e.Id == request.EntryId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);


            var user = await _userRepository.GetSingleAsync(u => u.Id == request.UserId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);


            var entryVote = await _entryVoteRepository
                .GetSingleAsync(ef => ef.EntryId == request.EntryId &&
                                ef.UserId == request.UserId);

            await _entryBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.EntryVote>(entryVote, BusinessConstants.EntryVote);

            var createEntryVoteEvent = new CreateEntryVoteEvent()
            {
                EntryId = request.EntryId,
                UserId = request.UserId,
                VoteType = request.VoteType
            };

            QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.VoteExchangeName,
                                        exchangeType: RabbitMQConstants.DefaultExchangeType,
                                        queueName: RabbitMQConstants.CreateEntryVoteQueueName,
                                        obj: createEntryVoteEvent);

            return new CreateEntryVoteCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryVoteCreated)
            };
        }
    }
}
