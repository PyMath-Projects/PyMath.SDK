namespace PyMathSDK.Common.MassTransit.Eventing.EventBus;

public interface IMassTransitEventBus
{
    void Publish<T>(T message) where T : class;
}