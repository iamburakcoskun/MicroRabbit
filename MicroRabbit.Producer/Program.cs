// See https://aka.ms/new-console-template for more information
using MicroRabbit.Producer.Helper;
using RabbitMQ.Client;

Console.WriteLine("Hello, World!");

var exhangeFactory = CreateSendMessageAndExchange.CreateExchange(ExchangeType.Headers);
exhangeFactory.CreateExchange();
var producer = CreateSendMessageAndExchange.CreateSendMessage(ExchangeType.Headers);
producer.SendMessage();
