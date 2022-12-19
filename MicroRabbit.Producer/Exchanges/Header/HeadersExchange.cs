
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

            #region Headers Exchange

            // First Queue
            channel.QueueDeclare(QUEUE_NAME_1,
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, "", map1);

            var map2 = new Dictionary<string, object>();
            map2.Add("x-match", "any");
            map2.Add("Fourth", "D");
            map2.Add("Third", "C");
            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, 
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, "", map2);

            var map3 = new Dictionary<string, object>();
            map3.Add("x-match", "all");
            map3.Add("First", "A");
            map3.Add("Third", "C");
            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, 
                    durable: false, //Data fiziksel olarak m� yoksa memoryde mi tutulsun
                    exclusive: false, //Ba�ka connectionlarda bu kuyru�a ula�abilsin mi
                    autoDelete: false, //E�er kuyruktaki son mesaj ula�t���nda kuyru�un silinmesini istiyorsak kullan�l�r.
                    arguments: null);//Exchangelere verilecek olan parametreler tan�mlamak i�in kullan�l�r.

            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, "", map3);
            #endregion

        }
    }

}
