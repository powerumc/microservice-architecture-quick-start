using Powerumc.RssFeeds.ValueObjects;

namespace Powerumc.RssFeeds.Domain.Events
{
    public class RssFeedCreatedDomainEvent : DomainEvent
    {
        public Author Author { get; }

        public RssFeedCreatedDomainEvent(Author author)
        {
            this.Author = author;
        }
    }
}