using Confluent.Kafka;

namespace PyMathSDK.Common.Kafka.Consumer;

public class BrokerConsumer<TKey, TValue> : IDisposable
{
    private readonly IConsumer<TKey, TValue> _consumer;
    private bool _disposed;

    public BrokerConsumer(string bootstrapServers, string groupId)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<TKey, TValue>(config).Build();
    }

    public ConsumeResult<TKey, TValue>? Consume(CancellationToken cancellationToken)
    {
        try
        {
            return _consumer.Consume(cancellationToken);
        }

        catch (ConsumeException e)
        {
            Console.WriteLine($"Consume error: {e.Error.Reason}");
            return null;
        }
    }

    public void Subscribe(string topic)
    {
        _consumer.Subscribe(topic);
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
            _consumer.Close();
            _consumer.Dispose();
        }

        _disposed = true;
    }

    ~BrokerConsumer()
    {
        Dispose(false);
    }
}