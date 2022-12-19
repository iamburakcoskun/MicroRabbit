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

            #region Fanout Exchange
            channel.QueueDeclare(QUEUE_NAME_1,
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY);

            channel.QueueDeclare(QUEUE_NAME_2,
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY);

            channel.QueueDeclare(QUEUE_NAME_3,
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY);
            #endregion

        }
    }
}
