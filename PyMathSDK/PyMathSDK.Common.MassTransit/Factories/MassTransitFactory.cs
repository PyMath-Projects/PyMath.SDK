using MassTransit;
using PyMathSDK.Common.MassTransit.Eventing.EventBus;

namespace PyMathSDK.Common.MassTransit.Factories;

public class MassTransitFactory
{
    public static IEventBus CreateEventBus(IBusControl bus)
    {
        return new EventBus(bus);
    }
}