using MassTransit;
using PyMathSDK.Common.MassTransit.Eventing.EventBus;

namespace PyMathSDK.Common.MassTransit.Factories;

public class MassTransitFactory
{
    public static IMassTransitEventBus CreateEventBus(IBusControl bus)
    {
        return new MassTransitEventBus(bus);
    }
}