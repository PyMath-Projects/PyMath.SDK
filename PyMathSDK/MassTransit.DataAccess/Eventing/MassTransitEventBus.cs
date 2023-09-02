namespace MassTransit.Eventing;

public class MassTransitEventBus : IEventBus
{
    private readonly List<object> _messagesToPublish = new List<object>();

    public MassTransitEventBus(IPublishEndpoint publishEndpoint)
    {
        Current = publishEndpoint;
    }

    public IPublishEndpoint Current { get; set; }

    public void Publish<T>(T message) where T : class
    {
        _messagesToPublish.Add(message);
    }

    public async Task FlushAllAsync(CancellationToken cancellationToken = default)
    {
        await Current.PublishBatch(_messagesToPublish, cancellationToken);
        _messagesToPublish.Clear();
    }
}