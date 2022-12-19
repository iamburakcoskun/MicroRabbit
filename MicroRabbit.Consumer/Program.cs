// See https://aka.ms/new-console-template for more information
using MicroRabbit.Consumer.Methods;

Console.WriteLine("Hello, World!");

Consumer.CreateConsumer("direct-queue-1");
Consumer.CreateConsumer("direct-queue-2");
Consumer.CreateConsumer("direct-queue-3");

Console.ReadKey();