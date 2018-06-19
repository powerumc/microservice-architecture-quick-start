using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Powerumc.RssFeeds.Domain;

namespace Powerumc.RssFeeds.Events
{
    public class EventBus : IEventBus
    {
        private ConcurrentDictionary<Type, List<Type>> _handlers =
            new ConcurrentDictionary<Type, List<Type>>();
        
        public void Publish(IDomainEvent @event)
        {
        }

        public void Subscribe(Type eventType, Type eventHandlerType)
        {
        }
    }
}