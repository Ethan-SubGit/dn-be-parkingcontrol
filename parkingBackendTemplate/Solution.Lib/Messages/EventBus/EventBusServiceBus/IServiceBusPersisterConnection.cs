namespace Message.EventBus.EventBus.EventBusServiceBus
{
    using Microsoft.Azure.ServiceBus;
    using System;

    public interface IServiceBusPersisterConnection : IDisposable
    {
        ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }

        ITopicClient CreateModel();
    }
}