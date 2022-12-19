using MicroRabbit.Producer.Interfaces;
using RabbitMQ.Client;

namespace MicroRabbit.Producer.Exchanges.Direct
{
    public class DirectExhange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "direct-exchange";
        public const string QUEUE_NAME_1 = "direct-queue-1";
        public const string QUEUE_NAME_2 = "direct-queue-2";
        public const string QUEUE_NAME_3 = "direct-queue-3";
        public const string ROUTING_KEY_1 = "direct-key-1";
        public const string ROUTING_KEY_2 = "direct-key-2";
        public const string ROUTING_KEY_3 = "direct-key-3";
        public void CreateExchange()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };

            //RabbitMQ ba�lant�s� i�in
            using var connection = factory.CreateConnection();

            //Channel olu�turma i�in
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct, true);

            //Kuyruk olu�turma
            #region Direct Exchange

            // First Queue
            channel.QueueDeclare(QUEUE_NAME_1,
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY_1);

            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, 
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY_2);

            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, 
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY_3);
            #endregion
        }
    }
}