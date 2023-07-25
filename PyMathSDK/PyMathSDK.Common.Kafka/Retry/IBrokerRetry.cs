using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Retry;

public interface IBrokerRetry
{
    Task<DeliveryResult<Null, string>> Retry(string topic, string message);
}