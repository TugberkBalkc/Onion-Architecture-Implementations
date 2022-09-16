using EksiSozluk.Projections.FavoriteWorkerService.Services;
using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using EksiSozluk.Shared.Events.Entry;
using EksiSozluk.Shared.Infrastructure;

namespace EksiSozluk.Projections.FavoriteWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFavoriteService _favoriteService;

        public Worker(ILogger<Worker> logger, IFavoriteService favoriteService)
        {
            _logger = logger;
            _favoriteService = favoriteService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            QueueFactory
                .CreateBasicConsumer()
                .EnsureExchange(RabbitMQConstants.FavoriteExchangeName)
                .EnsureQueue(RabbitMQConstants.CreateEntryCommentFavoriteQueueName, RabbitMQConstants.FavoriteExchangeName)
                .Recieve<CreateEntryFavoriteEvent>(createEntryFavoriteEvent =>
                {
                    _favoriteService.CreateEntryFavorite(createEntryFavoriteEvent);
                    _logger.LogInformation($"Recieved EntryId {createEntryFavoriteEvent.EntryId}");
                })
                .StartConsuming(RabbitMQConstants.CreateEntryCommentFavoriteQueueName);
        }
    }
}