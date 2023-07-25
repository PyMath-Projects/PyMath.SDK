using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Producer;

public interface IBrokerProducer
{
    Task<DeliveryResult<Null, string>> Produce(string topic, string message);
}