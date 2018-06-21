using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Powerumc.RssFeeds.Domain;

namespace Powerumc.RssFeeds.Events
{
    public class EventBus : IEventBus
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly ConcurrentDictionary<Type, List<Type>>
            _handlers = new ConcurrentDictionary<Type, List<Type>>();
        
        public EventBus(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Publish(IDomainEvent @event)
        {
            var eventType = @event.GetType();
            if (!_handlers.ContainsKey(eventType)) return;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                foreach (var handler in _handlers[eventType])
                {
                    var handlerObject = scope.ServiceProvider.GetService(handler);
                    var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
                    handlerType.GetMethod("Handle")?.Invoke(handlerObject, new object[] {@event});
                }
            }
        }

        public void Subscribe(Type eventType, Type eventHandlerType)
        {
            if (!_handlers.ContainsKey(eventType))
                _handlers.TryAdd(eventType, new List<Type>());

            var handler = _handlers[eventType];
            
            handler.Add(eventHandlerType);
        }
    }
}