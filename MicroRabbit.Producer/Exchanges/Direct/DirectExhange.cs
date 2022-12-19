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

            //RabbitMQ baðlantýsý için
            using var connection = factory.CreateConnection();

            //Channel oluþturma için
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct, true);

            //Kuyruk oluþturma
            #region Direct Exchange

            // First Queue
            channel.QueueDeclare(QUEUE_NAME_1,
                    durable: false, //Data fiziksel olarak mý yoksa memoryde mi tutulsun
                    exclusive: false, //Baþka connectionlarda bu kuyruða ulaþabilsin mi
                    autoDelete: false, //Eðer kuyruktaki son mesaj ulaþtýðýnda kuyruðun silinmesini istiyorsak kullanýlýr.
                    arguments: null);//Exchangelere verilecek olan parametreler tanýmlamak için kullanýlýr.

            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, ROUTING_KEY_1);

            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, 
                    durable: false, //Data fiziksel olarak mý yoksa memoryde mi tutulsun
                    exclusive: false, //Baþka connectionlarda bu kuyruða ulaþabilsin mi
                    autoDelete: false, //Eðer kuyruktaki son mesaj ulaþtýðýnda kuyruðun silinmesini istiyorsak kullanýlýr.
                    arguments: null);//Exchangelere verilecek olan parametreler tanýmlamak için kullanýlýr.

            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, ROUTING_KEY_2);

            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, 
                    durable: false, //Data fiziksel olarak mý yoksa memoryde mi tutulsun
                    exclusive: false, //Baþka connectionlarda bu kuyruða ulaþabilsin mi
                    autoDelete: false, //Eðer kuyruktaki son mesaj ulaþtýðýnda kuyruðun silinmesini istiyorsak kullanýlýr.
                    arguments: null);//Exchangelere verilecek olan parametreler tanýmlamak için kullanýlýr.

            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, ROUTING_KEY_3);
            #endregion
        }
    }
}