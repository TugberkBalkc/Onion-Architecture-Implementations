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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.RemoveFavorite
{
    public class DeleteEntryFavoriteCommandHandler : IRequestHandler<DeleteEntryFavoriteCommandRequest, DeleteEntryFavoriteCommandResponse>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEntryFavoriteRepository _entryFavoriteRepository;
        private readonly IMapper _mapper;
        private readonly EntryBusinessRules _entryBusinessRules;

        public DeleteEntryFavoriteCommandHandler(
            IEntryRepository entryRepository, IUserRepository userRepository,
            IEntryFavoriteRepository entryFavoriteRepository, IMapper mapper,
            EntryBusinessRules entryBusinessRules)
        {
            _entryRepository = entryRepository;
            _userRepository = userRepository;
            _entryFavoriteRepository = entryFavoriteRepository;
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<DeleteEntryFavoriteCommandResponse> Handle(DeleteEntryFavoriteCommandRequest request, CancellationToken cancellationToken)
        {
            var entry = await _entryRepository.GetSingleAsync(e => e.Id == request.EntryId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Entry>(entry, BusinessConstants.Entry);


            var user = await _userRepository.GetSingleAsync(u => u.Id == request.UserId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);


            var entryFavorite = await _entryFavoriteRepository
                .GetSingleAsync(ef => ef.EntryId == request.EntryId &&
                                ef.UserId == request.UserId);

            await _entryBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EntryFavorite>(entryFavorite, BusinessConstants.EntryFavorite);


            var deleteEntryFavoriteEvent = new DeleteEntryFavoriteEvent()
            {
                EntryId = request.EntryId,
                UserId = request.UserId
            };

            QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.FavoriteExchangeName,
                                        exchangeType: RabbitMQConstants.DefaultExchangeType,
                                        queueName: RabbitMQConstants.DeleteEntryFavoriteQueueName,
                                        obj: deleteEntryFavoriteEvent);

            return new DeleteEntryFavoriteCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryRemovedInFavorites)
            };
        }
    }
}
