using System;
using Powerumc.RssFeeds.Domain;

namespace Powerumc.RssFeeds.Events
{
    public interface IEventBus
    {
        void Publish(IDomainEvent @event);
        void Subscribe(Type eventType, Type eventHandlerType);
    }
}