namespace PyMathSDK.Common.MassTransit.Eventing.Messaging;

public interface IMessageHandler<TMessage>
    where TMessage : class
{
    Task HandleAsync(TMessage message, CancellationToken cancellationToken = default);
}