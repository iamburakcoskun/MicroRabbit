using MicroRabbit.Producer.Interfaces;
using RabbitMQ.Client;

namespace RabbitMQ.Producer.Exchanges.Topic
{
    public class TopicExchange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "topic-exchange";
        public const string QUEUE_NAME_1 = "topic-queue-1";
        public const string QUEUE_NAME_2 = "topic-queue-2";
        public const string QUEUE_NAME_3 = "topic-queue-3";

        public const string ROUTING_PATTERN_1 = "asia.china.*";
        public const string ROUTING_PATTERN_2 = "asia.china.#";
        public const string ROUTING_PATTERN_3 = "asia.*.*";

        public const string ROUTING_KEY_1 = "asia.china.nanjing";
        public const string ROUTING_KEY_2 = "asia.china";
        public const string ROUTING_KEY_3 = "asia.china.beijing";

        public void CreateExchange()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };

            //Create Connection
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Topic, true);

            #region Topic Exchange
            channel.QueueDeclare(QUEUE_NAME_1,
                 durable: false, //Data fiziksel olarak mý yoksa memoryde mi tutulsun
                    exclusive: false, //Baþka connectionlarda bu kuyruða ulaþabilsin mi
                    autoDelete: false, //Eðer kuyruktaki son mesaj ulaþtýðýnda kuyruðun silinmesini istiyorsak kullanýlýr.
                    arguments: null);//Exchangelere verilecek olan parametreler tanýmlamak için kullanýlýr.

            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_PATTERN_1);

            channel.QueueDeclare(QUEUE_NAME_2,
                 durable: false, //Data fiziksel olarak mý yoksa memoryde mi tutulsun
                    exclusive: false, //Baþka connectionlarda bu kuyruða ulaþabilsin mi
                    autoDelete: false, //Eðer kuyruktaki son mesaj ulaþtýðýnda kuyruðun silinmesini istiyorsak kullanýlýr.
                    arguments: null);//Exchangelere verilecek olan parametreler tanýmlamak için kullanýlýr.

            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_PATTERN_2);

            channel.QueueDeclare(QUEUE_NAME_3,
                 durable: false, //Data fiziksel olarak mý yoksa memoryde mi tutulsun
                    exclusive: false, //Baþka connectionlarda bu kuyruða ulaþabilsin mi
                    autoDelete: false, //Eðer kuyruktaki son mesaj ulaþtýðýnda kuyruðun silinmesini istiyorsak kullanýlýr.
                    arguments: null);//Exchangelere verilecek olan parametreler tanýmlamak için kullanýlýr.

            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_PATTERN_3);
            #endregion
        }
    }



}
