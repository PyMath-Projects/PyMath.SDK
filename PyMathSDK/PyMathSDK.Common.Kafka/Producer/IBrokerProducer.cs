using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Producer;

public interface IBrokerProducer : IDisposable
{
    Task<DeliveryResult<Null, string>?> ProduceAsync(string topic, string message);
}