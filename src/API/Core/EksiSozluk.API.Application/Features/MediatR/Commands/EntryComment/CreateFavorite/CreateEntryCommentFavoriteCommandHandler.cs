using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.EntryComment;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using EksiSozluk.Shared.Events.EntryComment;
using EksiSozluk.Shared.Infrastructure;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.CreateFavorite
{
    public class CreateEntryCommentFavoriteCommandHandler : IRequestHandler<CreateEntryCommentFavoriteCommandRequest, CreateEntryCommentFavoriteCommandResponse>
    {
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEntryCommentFavoriteRepository _entryCommentFavoriteRepository;
        private readonly IMapper _mapper;
        private readonly EntryCommentBusinessRules _entryCommentBusinessRules;

        public CreateEntryCommentFavoriteCommandHandler
            (IEntryCommentRepository entryCommentRepository, IUserRepository userRepository, 
            IEntryCommentFavoriteRepository entryCommentFavoriteRepository, IMapper mapper,
            EntryCommentBusinessRules entryCommentBusinessRules)
        {
            _entryCommentRepository = entryCommentRepository;
            _userRepository = userRepository;
            _entryCommentFavoriteRepository = entryCommentFavoriteRepository;
            _mapper = mapper;
            _entryCommentBusinessRules = entryCommentBusinessRules;
        }

        public async Task<CreateEntryCommentFavoriteCommandResponse> Handle(CreateEntryCommentFavoriteCommandRequest request, CancellationToken cancellationToken)
        {
            var entryComment = await _entryCommentRepository.GetSingleAsync(ec => ec.Id == request.EntryCommentId);

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.EntryComment>(entryComment, BusinessConstants.EntryComment);


            var user = await _userRepository.GetSingleAsync(u => u.Id == request.UserId);

            await _entryCommentBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);


            var entryCommentFavorite = await _entryCommentFavoriteRepository
                .GetSingleAsync(ecf => ecf.EntryCommentId == request.EntryCommentId &&
                                ecf.UserId == request.UserId);

            await _entryCommentBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.EntryCommentFavorite>(entryCommentFavorite, BusinessConstants.EntryCommentFavorite);
          
            var createEntryCommentFavoriteEvent = new CreateEntryCommentFavoriteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                UserId = request.UserId
            };

            QueueFactory.PublishMessage(exchangeName: RabbitMQConstants.FavoriteExchangeName,
                                        exchangeType: RabbitMQConstants.DefaultExchangeType,
                                        queueName: RabbitMQConstants.CreateEntryCommentFavoriteQueueName,
                                        obj: createEntryCommentFavoriteEvent);

            return new CreateEntryCommentFavoriteCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<bool>
                (data: true, title: ServerTitles.Successful, devNote: "", message: ServerMessages.EntryCommentFavoriteCreated)
            };
        }
    }
}
