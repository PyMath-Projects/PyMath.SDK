using Confluent.Kafka;
using PyMathSDK.Common.Kafka.Configuration;

namespace PyMathSDK.Common.Kafka.Producer;

public class BrokerProducer<TKey, TValue> : IBrokerProducer<TKey, TValue>
{
    private bool _disposed;
    private readonly IProducer<TKey, TValue> _producer;
    private readonly KafkaConfiguration _kafkaConfiguration;

    public BrokerProducer(KafkaConfiguration kafkaConfiguration)
    {
        _kafkaConfiguration = kafkaConfiguration;
        _producer = new ProducerBuilder<TKey, TValue>(_kafkaConfiguration.ProducerConfiguration)
            .Build();
    }

    public async Task<DeliveryResult<TKey, TValue>?> ProduceAsync(string topic, TKey messageKey, TValue message)
    {
        try
        {
            var producerMessage = new Message<TKey, TValue>
            {
                Key = messageKey,
                Value = message
            };
            return await _producer.ProduceAsync(topic, producerMessage);
        }
        catch (ProduceException<TKey, TValue> e)
        {
            Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            return null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Task<DeliveryResult<Null, string>?> ProduceAsync(string topic, string message)
    {
        throw new NotImplementedException();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            _producer.Flush(TimeSpan.FromSeconds(_kafkaConfiguration.ProducerFlushTimeOutSeconds));
            _producer.Dispose();
        }

        _disposed = true;
    }
}