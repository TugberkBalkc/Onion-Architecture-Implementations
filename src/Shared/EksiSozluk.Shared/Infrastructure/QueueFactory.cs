using EksiSozluk.Shared.Constants.MessageBrokers.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EksiSozluk.Shared.Infrastructure
{
    public static class QueueFactory
    {
        private static IConnection _connection;
        private static IConnection connection => _connection ?? (_connection = CreateConnection(RabbitMQConstants.Host));

        private static IModel _channel;
        private static IModel channel => _channel ?? (_channel = CreateChannel());

        public static void PublishMessage(String exchangeName,
                                          String exchangeType,
                                          String queueName,
                                          object obj)
        {
            var channel = CreateBasicConsumer()
                         .EnsureExchange(exchangeName, exchangeType)
                         .EnsureQueue(queueName, exchangeName)
                         .Model;

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));

            channel.BasicPublish(exchange: exchangeName,
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }

        public static EventingBasicConsumer CreateBasicConsumer()
        {
            return new EventingBasicConsumer(channel);
        }

        public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer eventingBasicConsumer,
                                                           String exchangeName,
                                                           String exchangeType = RabbitMQConstants.DefaultExchangeType)
        {
            eventingBasicConsumer.Model.ExchangeDeclare(exchange: exchangeName,
                                                        type: exchangeType,
                                                        durable: false,
                                                        autoDelete: false);

            return eventingBasicConsumer;
        }

        public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer eventingBasicConsumer,
                                                        String queueName,
                                                        String exchangeName) 
        {
            eventingBasicConsumer.Model.QueueDeclare(queue: queueName,
                                                     durable: false,
                                                     exclusive: false,
                                                     autoDelete: false,
                                                     arguments: null);

            eventingBasicConsumer.Model.QueueBind(queue: queueName,
                                                  exchange: exchangeName,
                                                  routingKey: queueName,
                                                  arguments: null);
            
            return eventingBasicConsumer;
        }

        public static EventingBasicConsumer Recieve<T>(this EventingBasicConsumer eventingBasicConsumer, Action<T> action)
        {
            eventingBasicConsumer.Received += (channel, eventArgs) =>
            {
                var bodyArray = eventArgs.Body.ToArray();

                var message = Encoding.UTF8.GetString(bodyArray);

                var model = JsonSerializer.Deserialize<T>(message);

                action(model);

                eventingBasicConsumer.Model.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);
            };

            return eventingBasicConsumer;
        }

        public static EventingBasicConsumer StartConsuming(this EventingBasicConsumer eventingBasicConsumer,
                                                           String queueName)
        {
            eventingBasicConsumer.Model.BasicConsume(queue: queueName,
                                                     autoAck: false,
                                                     consumer: eventingBasicConsumer);

            return eventingBasicConsumer;
        }

        private static IConnection CreateConnection(String host)
        {
            var connectionFactory = new ConnectionFactory()
            {
               HostName = host
            };

            return connectionFactory.CreateConnection();
        }

        private static IModel CreateChannel()
        {
            return connection.CreateModel();
        }
    }
}
