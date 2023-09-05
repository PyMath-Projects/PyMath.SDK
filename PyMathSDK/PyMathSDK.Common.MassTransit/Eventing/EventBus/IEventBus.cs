namespace PyMathSDK.Common.MassTransit.Eventing.EventBus;

public interface IEventBus
{
    Task PublishAsync<T>(T message) where T : class;
    
    void Publish<T>(T message) where T : class;
}