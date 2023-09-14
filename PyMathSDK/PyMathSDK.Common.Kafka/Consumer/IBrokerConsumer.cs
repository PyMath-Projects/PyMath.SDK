using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Consumer;

public interface IBrokerConsumer
{
    Task<DeliveryResult<Null, string>> Consume(string topic, string message);
}