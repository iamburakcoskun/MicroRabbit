using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Consumer.Methods
{
    public static class Consumer
    {
        public const string EXCHANGE_NAME = "direct-exchange";
        public const string QUEUE_NAME_1 = "direct-queue-1";
        public const string QUEUE_NAME_2 = "direct-queue-2";
        public const string QUEUE_NAME_3 = "direct-queue-3";
        public const string ROUTING_KEY_1 = "direct-key-1";
        public const string ROUTING_KEY_2 = "direct-key-2";
        public const string ROUTING_KEY_3 = "direct-key-3";

        //public const string EXCHANGE_NAME = "topic-exchange";
        //public const string QUEUE_NAME_1 = "topic-queue-1";
        //public const string QUEUE_NAME_2 = "topic-queue-2";
        //public const string QUEUE_NAME_3 = "topic-queue-3";

        //public const string ROUTING_PATTERN_1 = "asia.china.*";
        //public const string ROUTING_PATTERN_2 = "asia.china.#";
        //public const string ROUTING_PATTERN_3 = "asia.*.*";

        //public const string ROUTING_KEY_1 = "asia.china.nanjing";
        //public const string ROUTING_KEY_2 = "asia.china";
        //public const string ROUTING_KEY_3 = "asia.china.beijing";

        //public const string EXCHANGE_NAME = "header-exchange";
        //public const string QUEUE_NAME_1 = "header-queue-1";
        //public const string QUEUE_NAME_2 = "header-queue-2";
        //public const string QUEUE_NAME_3 = "header-queue-3";

        //public const string EXCHANGE_NAME = "fanout-exchange";
        //public const string QUEUE_NAME_1 = "fanout-queue-1";
        //public const string QUEUE_NAME_2 = "fanout-queue-2";
        //public const string QUEUE_NAME_3 = "fanout-queue-3";

        public static void CreateConsumer(string queue)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };

            //Create Connection
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            #region Direct Exchange
            // First Queue
            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY_1);

            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY_2);

            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY_3);
            #endregion

            #region Topic Exchange
            //channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_PATTERN_1);

            //channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_PATTERN_2);

            //channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_PATTERN_3); 
            #endregion

            #region Headers Exchange
            //// First Queue
            //channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, "", map1);

            //var map2 = new Dictionary<string, object>();
            //map2.Add("x-match", "any");
            //map2.Add("Fourth", "D");
            //map2.Add("Third", "C");
            //// Second Queue
            //channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, "", map2);

            //var map3 = new Dictionary<string, object>();
            //map3.Add("x-match", "all");
            //map3.Add("First", "A");
            //map3.Add("Third", "C");
            //// Third Queue
            //channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, "", map3); 
            #endregion

            #region Fanout Exchange
            //channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY);

            //channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY);

            //channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            //channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY);
            #endregion

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
