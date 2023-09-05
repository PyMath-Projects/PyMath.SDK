namespace PyMathSDK.Common.MassTransit.Eventing.EventBus;

public interface IMassTransitEventBus
{
    Task Publish<T>(T message) where T : class;
}