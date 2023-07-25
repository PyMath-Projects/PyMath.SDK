using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Producer;

public class BrokerProducer : IBrokerProducer
{
    public Task<DeliveryResult<Null, string>> Produce(string topic, string message)
    {
        throw new NotImplementedException();
    }
}