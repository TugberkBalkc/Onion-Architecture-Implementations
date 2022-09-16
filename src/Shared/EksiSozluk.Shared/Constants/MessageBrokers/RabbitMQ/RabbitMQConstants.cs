using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ
{
    public class RabbitMQConstants
    {
        //Default Configurations
        public const String Host = "localhost";
        public const String DefaultExchangeType = "direct";
        //End Of Section

        //Vote AMQP Entities
        public const String VoteExchangeName = "VoteExchange";
        public const String CreateEntryVoteQueueName = "CreateEntryVoteQueue";
        public const String DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";
        public const String CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";
        public const String DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";
        //End Of Section

        //Favorite AMQP Entities
        public const String FavoriteExchangeName = "FavoriteExchange";
        public const String CreateEntryFavoriteQueueName = "CreateEntryFavoriteQueue";
        public const String DeleteEntryFavoriteQueueName = "DeleteEntryFavoriteQueue";
        public const String CreateEntryCommentFavoriteQueueName = "CreateEntryCommentFavoriteQueue";
        public const String DeleteEntryCommentFavoriteQueueName = "DeleteEntryCommentFavoriteQueue";
        //End Of Section

        //User AMQP Entities
        public const String UserExchangeName = "UserExchange";
        public const String UserEmailChangedQueueName = "UserEmailChangedQueue";
        //End Of Section
    }
}
