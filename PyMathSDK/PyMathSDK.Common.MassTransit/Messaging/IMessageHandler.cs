namespace PyMathSDK.Common.MassTransit.Messaging;

public interface IMessageHandler<TMessage> where TMessage : class
{
    Task HandleAsync(TMessage message, CancellationToken cancellationToken = default);
}