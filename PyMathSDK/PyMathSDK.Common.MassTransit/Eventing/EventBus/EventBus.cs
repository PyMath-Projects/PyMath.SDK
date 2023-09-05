using MassTransit;

namespace PyMathSDK.Common.MassTransit.Eventing.EventBus;

public class EventBus : IEventBus, IDisposable
{
    private readonly List<object> _messagesToPublish = new List<object>();
    public IPublishEndpoint Current { get; set; }

    public EventBus(IPublishEndpoint publishEndpoint)
    {
        Current = publishEndpoint;
    }


    public Task PublishAsync<T>(T message) where T : class
    {
        _messagesToPublish.Add(message);
        return Task.CompletedTask;
    }

    public void Publish<T>(T message) where T : class
    {
        _messagesToPublish.Add(message);
    }

    public async Task FlushAllAsync(CancellationToken cancellationToken = default)
    {
        await Current.PublishBatch(_messagesToPublish, cancellationToken);
        _messagesToPublish.Clear();
    }

    public void Dispose()
    {
    }
}