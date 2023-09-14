using MassTransit;

namespace PyMathSDK.Common.MassTransit.Messaging;

public class MassTransitConsumerDefinition<THandler, TMessage> : ConsumerDefinition<MassTransitConsumer<THandler, TMessage>>
    where TMessage : class
    where THandler : IMessageHandler<TMessage>
{
    private readonly IServiceProvider _serviceProvider;

    public MassTransitConsumerDefinition(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<MassTransitConsumer<THandler, TMessage>> consumerConfigurator)
    {
    }
}