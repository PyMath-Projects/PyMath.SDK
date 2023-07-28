using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Producer;

public interface IBrokerProducer<TKey, TValue> : IDisposable
{
    Task<DeliveryResult<TKey, TValue>?> ProduceAsync(string topic, TKey messageKey, TValue message);
}