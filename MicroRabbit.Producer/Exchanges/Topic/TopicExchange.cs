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
                 durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_PATTERN_1);

            channel.QueueDeclare(QUEUE_NAME_2,
                 durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_PATTERN_2);

            channel.QueueDeclare(QUEUE_NAME_3,
                 durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_PATTERN_3);
            #endregion
        }
    }



}
