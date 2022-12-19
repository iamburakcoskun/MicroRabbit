using MicroRabbit.Producer.Exchanges.Direct;
using MicroRabbit.Producer.Helper;
using MicroRabbit.Producer.Interfaces;
using RabbitMQ.Client;

namespace RabbitMQ.Producer.Exchanges.Direct
{
    public class DirectMessage : ISendMessage
    {
        public string Message1 => "First Direct Message";
        public string Message2 => "Second Direct Message";
        public string Message3 => "Third Direct Message";
        public void SendMessage()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };

            //Create Connection
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            // First message sent by using ROUTING_KEY_1
            channel.BasicPublish(DirectExhange.EXCHANGE_NAME, DirectExhange.ROUTING_KEY_1, null, Message1.GetBytes());
            Console.Write($" Message Sent {Message1}");

            // Second message sent by using ROUTING_KEY_2
            channel.BasicPublish(DirectExhange.EXCHANGE_NAME, DirectExhange.ROUTING_KEY_2, null, Message2.GetBytes());
            Console.Write($" Message Sent {Message2}");

            // Third message sent by using ROUTING_KEY_3
            channel.BasicPublish(DirectExhange.EXCHANGE_NAME, DirectExhange.ROUTING_KEY_3, null, Message3.GetBytes());
             Console.Write($" Message Sent {Message3}");
        }

    }
}
