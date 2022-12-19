
using System.Collections.Generic;
using MicroRabbit.Producer.Interfaces;
using RabbitMQ.Client;

namespace MicroRabbit.Producer.Exchanges.Headers
{
    public class HeadersExchange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "header-exchange";
        public const string QUEUE_NAME_1 = "header-queue-1";
        public const string QUEUE_NAME_2 = "header-queue-2";
        public const string QUEUE_NAME_3 = "header-queue-3";
        public void CreateExchange()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };

            //Create Connection
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Headers, true);
            var map1 = new Dictionary<string, object>();
            map1.Add("x-match", "any");
            map1.Add("First", "A");
            map1.Add("Fourth", "D");
            
        }
    }

}
