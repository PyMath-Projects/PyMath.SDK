namespace PyMathSDK.Common.MassTransit.Eventing.EventBus;

public interface IEventBus
{
    Task Publish<T>(T message) where T : class;
}