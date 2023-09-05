using MassTransit;

namespace PyMathSDK.Common.MassTransit.Eventing.EventBus;

public class EventBus : IEventBus, IDisposable
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly List<object> _messagesToPublish = new List<object>();
    public IPublishEndpoint Current { get; set; }

    public EventBus(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        Current = _publishEndpoint;
    }
    
    public Task Publish<T>(T message) where T : class
    {
        _messagesToPublish.Add(message);
        return Task.CompletedTask;
    }

    public async Task FlushAllAsync(CancellationToken cancellationToken = default)
    {
        await _publishEndpoint.PublishBatch(_messagesToPublish, cancellationToken);
        _messagesToPublish.Clear();
    }

    public void Dispose()
    {
    }
}