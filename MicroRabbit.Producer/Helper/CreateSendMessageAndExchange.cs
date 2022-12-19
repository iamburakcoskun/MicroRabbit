using MicroRabbit.Producer.Exchanges.Direct;
using MicroRabbit.Producer.Exchanges.Fanout;
using MicroRabbit.Producer.Exchanges.Headers;
using MicroRabbit.Producer.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Producer.Exchanges.Direct;
using RabbitMQ.Producer.Exchanges.Fanout;
using RabbitMQ.Producer.Exchanges.Headers;
using RabbitMQ.Producer.Exchanges.Topic;

namespace MicroRabbit.Producer.Helper
{
    public static class CreateSendMessageAndExchange
    {
        public static ISendMessage CreateSendMessage(string exchangeType)
        {

            switch (exchangeType)
            {
                case ExchangeType.Direct:
                    return new DirectMessage();
                case ExchangeType.Headers:
                    return new HeadersMessage();
                case ExchangeType.Topic:
                    return new TopicMessage();
                case ExchangeType.Fanout:
                    return new FanoutMessage();
                default:
                    throw new Exception("there is no properly exchange type");
            }
        }

        public static IExchangeFactory CreateExchange(string exchangeType)
        {
            switch (exchangeType)
            {
                case ExchangeType.Direct:
                    return new DirectExhange();
                case ExchangeType.Headers:
                    return new HeadersExchange();
                case ExchangeType.Topic:
                    return new TopicExchange();
                case ExchangeType.Fanout:
                    return new FanoutExchange();
                default:
                    throw new Exception("there is no properly exchange type");
            }
        }
    }
}
