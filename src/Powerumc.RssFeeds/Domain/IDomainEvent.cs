using System;

namespace Powerumc.RssFeeds.Domain
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTime CreateDate { get; }
    }
}