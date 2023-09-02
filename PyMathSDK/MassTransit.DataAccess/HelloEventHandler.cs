using MassTransit.Eventing;

namespace MassTransit;

public class HelloEventHandler : IMessageHandler<HelloEvent>
{
    public Task HandleAsync(HelloEvent message, CancellationToken cancellationToken = default)
    {
        Console.Write("Works");
        return Task.CompletedTask;
    }
}