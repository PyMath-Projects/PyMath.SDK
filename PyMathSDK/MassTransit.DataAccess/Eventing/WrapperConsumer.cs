using System.Transactions;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Eventing;

public class WrapperConsumer<THandler, TMessage> : IConsumer<TMessage>
    where TMessage : class
    where THandler : IMessageHandler<TMessage>
{
    private readonly IServiceProvider _serviceProvider;

    public WrapperConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Consume(ConsumeContext<TMessage> context)
    {
        var eventBus = _serviceProvider.GetService<MassTransitEventBus>()!;
        eventBus.Current = context;

        using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                   new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
        {
            var handler = _serviceProvider.GetService<THandler>()!;
            await handler.HandleAsync(context.Message, context.CancellationToken);
            await eventBus.FlushAllAsync(context.CancellationToken);
            transaction.Complete();
        }
    }
}

public class WrapperConsumerDefinition<THandler, TMessage> : ConsumerDefinition<WrapperConsumer<THandler, TMessage>>
    where TMessage : class
    where THandler : IMessageHandler<TMessage>
{
    private readonly IServiceProvider _serviceProvider;

    public WrapperConsumerDefinition(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<WrapperConsumer<THandler, TMessage>> consumerConfigurator)
    {
    }
}