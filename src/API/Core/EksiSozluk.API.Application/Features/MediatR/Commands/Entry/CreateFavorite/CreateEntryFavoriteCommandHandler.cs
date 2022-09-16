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
using EksiSozluk.Shared.Events.EntryComment;
using EksiSozluk.Shared.Infrastructure;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.AddFavorite
{
    public class CreateEntryFavoriteCommandHandler : IRequestHandler<CreateEntryFavoriteCommandRequest, CreateEntryFavoriteCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEntryFavoriteRepository _entryFavoriteRepository;
        private readonly IMapper _mapper;
        private readonly EntryBusinessRules _entryBusinessRules;

        public CreateEntryFavoriteCommandHandler(
            IEntryRepository entryRepository, IEntryFavoriteRepository entryFavoriteRepository, 
            IUserRepository userRepository, IMapper mapper,
            EntryBusinessRules entryBusinessRules)
        {
            _entryRepository = entryRepository;
            _entryFavoriteRepository = entryFavoriteRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<CreateEntryFavoriteCommandResponse> Handle(CreateEntryFavoriteCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository.GetSingleAsync(e => e.Id == request.EntryId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);

            
            var user = await _userRepository.GetSingleAsync(u => u.Id == request.UserId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);


            var entryFavorite = await _entryFavoriteRepository
                .GetSingleAsync(ef => ef.EntryId == request.EntryId &&
                                ef.UserId == request.UserId);

            await _entryBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.EntryFavorite>(entryFavorite, BusinessConstants.EntryFavorite);

            var createEntryFavoriteEvent = new CreateEntryFavoriteEvent()
            {
                EntryId = request.EntryId,
                UserId = request.UserId
            };

            QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.FavoriteExchangeName,
                                        exchangeType: RabbitMQConstants.DefaultExchangeType,
                                        queueName: RabbitMQConstants.CreateEntryFavoriteQueueName,
                                        obj: createEntryFavoriteEvent);

            return new CreateEntryFavoriteCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryAddedToFavorites)
            };
        }
    }
}
