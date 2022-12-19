using MicroRabbit.Producer.Interfaces;
using RabbitMQ.Client;

namespace MicroRabbit.Producer.Exchanges.Fanout
{
    public class FanoutExchange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "fanout-exchange";
        public const string QUEUE_NAME_1 = "fanout-queue-1";
        public const string QUEUE_NAME_2 = "fanout-queue-2";
        public const string QUEUE_NAME_3 = "fanout-queue-3";

        public static string ROUTING_KEY = "";
        public void CreateExchange()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };

            //Create Connection
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Fanout, true);
        }
    }
}
