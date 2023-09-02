namespace MassTransit.Eventing;

public interface IEventBus
{
    void Publish<T>(T message)
        where T : class;
    Task FlushAllAsync(CancellationToken cancellationToken = default);
}