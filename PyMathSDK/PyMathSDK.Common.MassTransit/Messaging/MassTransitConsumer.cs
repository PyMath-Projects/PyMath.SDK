using System.Transactions;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PyMathSDK.Common.MassTransit.Eventing.EventBus;

namespace PyMathSDK.Common.MassTransit.Messaging;

public class MassTransitConsumer<THandler, TMessage> : IConsumer<TMessage>
    where TMessage : class
    where THandler : IMessageHandler<TMessage>
{
    private readonly IServiceProvider _serviceProvider;

    public MassTransitConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    // This seems like a good use of the decorator pattern. Maybe, maybe not.
    public async Task Consume(ConsumeContext<TMessage> context)
    {
        var eventBus = _serviceProvider.GetService<MassTransitEventBus>()!;
        eventBus.Current = context;

        using var transaction = new TransactionScope(TransactionScopeOption.Required,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            },
            TransactionScopeAsyncFlowOption.Enabled);
        var handler = _serviceProvider.GetService<THandler>()!;
        await handler.HandleAsync(context.Message, context.CancellationToken);
        await eventBus.FlushAllAsync(context.CancellationToken);
        transaction.Complete();
    }
}

public class WrapperConsumerDefinition<THandler, TMessage> : ConsumerDefinition<MassTransitConsumer<THandler, TMessage>>
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
        IConsumerConfigurator<MassTransitConsumer<THandler, TMessage>> consumerConfigurator)
    {
    }
}