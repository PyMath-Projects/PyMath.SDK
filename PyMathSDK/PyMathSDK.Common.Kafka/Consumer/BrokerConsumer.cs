using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Consumer;

public class BrokerConsumer : IBrokerConsumer
{
    public Task<DeliveryResult<Null, string>> Consume(string topic, string message)
    {
        throw new NotImplementedException();
    }
}