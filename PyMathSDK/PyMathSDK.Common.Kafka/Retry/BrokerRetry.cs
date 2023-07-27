using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Retry;

public class BrokerRetry : IBrokerRetry
{
    public Task<DeliveryResult<Null, string>> Retry(string topic, string message)
    {
        throw new NotImplementedException();
    }
}