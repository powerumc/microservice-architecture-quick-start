using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Powerumc.RssFeeds.Domain
{
    public class DomainModel
    {
        public TraceId TraceId { get; set; }
        
        public List<IDomainEvent> DomainEvents = new List<IDomainEvent>();

        public void AddDomainEvent(IDomainEvent @event)
        {
            this.DomainEvents.Add(@event);
        }

        public void RemoveDomainEvent(IDomainEvent @event)
        {
            this.DomainEvents.Remove(@event);
        }

        public void ClearDomainEvent(IDomainEvent @evnet)
        {
            this.DomainEvents.Clear();
        }
    }
}