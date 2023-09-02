namespace MassTransit.Eventing;

public interface IMessageHandler<TMessage>
    where TMessage : class
{
    Task HandleAsync(TMessage message, CancellationToken cancellationToken = default);
}