using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Consumer;

public class BrokerConsumer : IBrokerConsumer
{
    private readonly ConsumerConfig _config;

    public BrokerConsumer(ConsumerConfig config)
    {
        _config = config;
    }

    public Task<DeliveryResult<Null, string>> Consume(string topic, string message)
    {
        throw new NotImplementedException();
    }
}