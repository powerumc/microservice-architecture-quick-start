using Powerumc.RssFeeds.ValueObjects;

namespace Powerumc.RssFeeds.Domain.Events
{
    public class RssFeedCreateDomainEvent : DomainEvent
    {
        public Author Author { get; }

        public RssFeedCreateDomainEvent(Author author)
        {
            this.Author = author;
        }
    }
}