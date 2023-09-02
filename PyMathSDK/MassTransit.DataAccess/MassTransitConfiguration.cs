
using MassTransit.Configuration;
using MassTransit.Eventing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit;


public static class MassTransitConfiguration
{
    public static void AddMassTransitConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.AddConsumers();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.UseMessageRetry(r => r.Interval(
                    configuration.GetValue<int?>("MassTransit:Retry:RetryCount") ?? 10,
                    configuration.GetValue<TimeSpan?>("MassTransit:Retry:Interval") ?? TimeSpan.FromSeconds(30)));
                cfg.Host(configuration["RabbitMq:Host"], host =>
                {
                    host.Username(configuration["RabbitMq:Username"]);
                    host.Password(configuration["RabbitMq:Password"]);
                });
                cfg.ConfigureEndpoints(context);
                cfg.ConfigureNonDefaultEndpoints(context);
            });
        });
    }

    private static void AddConsumers(this IRegistrationConfigurator cfg)
    {
        cfg.AddConsumer<WrapperConsumer<IMessageHandler<HelloEvent>, HelloEvent>>(typeof(WrapperConsumerDefinition<IMessageHandler<HelloEvent>, HelloEvent>));
    }

    private static void ConfigureNonDefaultEndpoints(
        this IRabbitMqBusFactoryConfigurator cfg,
        IBusRegistrationContext context)
    {
    }

    private static void AddCustomConsumerEndpoint<TConsumer>(
        this IRabbitMqBusFactoryConfigurator cfg,
        IBusRegistrationContext context,
        string instanceId,
        Action<IRabbitMqReceiveEndpointConfigurator> configuration)
        where TConsumer : class, IConsumer
    {
        cfg.ReceiveEndpoint(
            new ConsumerEndpointDefinition<TConsumer>(new EndpointSettings<IEndpointDefinition<TConsumer>>
            {
                InstanceId = instanceId
            }),
            KebabCaseEndpointNameFormatter.Instance,
            endpoint =>
            {
                configuration.Invoke(endpoint);
                endpoint.ConfigureConsumer<TConsumer>(context);
            });
    }
}