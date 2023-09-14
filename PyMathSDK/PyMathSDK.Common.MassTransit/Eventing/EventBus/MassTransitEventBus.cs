using MassTransit;

namespace PyMathSDK.Common.MassTransit.Eventing.EventBus;

public class MassTransitEventBus : IMassTransitEventBus, IDisposable
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly List<object> _messagesToPublish = new List<object>();
    public IPublishEndpoint Current { get; set; }

    public MassTransitEventBus(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        Current = _publishEndpoint;
    }
    
    public void Publish<T>(T message) where T : class
    {
        _messagesToPublish.Add(message);
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