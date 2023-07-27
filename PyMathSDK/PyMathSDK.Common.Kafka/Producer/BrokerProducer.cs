using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Producer;

public class BrokerProducer : IBrokerProducer
{
    private readonly IProducer<Null, string> _producer;
    private bool _disposed;

    public BrokerProducer(string bootstrapServers)
    {
        var config = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task<DeliveryResult<Null, string>?> ProduceAsync(string topic, string message)
    {
        try
        {
            var msg = new Message<Null, string> { Value = message };
            return await _producer.ProduceAsync(topic, msg);
        }
        catch (ProduceException<Null, string> e)
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

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
            _producer.Dispose();
        }

        _disposed = true;
    }
}