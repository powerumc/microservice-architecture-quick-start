using System;

namespace Powerumc.RssFeeds.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedDate { get; } = DateTime.Now;
    }
}