using Powerumc.RssFeeds.Domain.Events;
using Powerumc.RssFeeds.ValueObjects;

namespace Powerumc.RssFeeds.Domain.Models
{
    public class RssFeedDomainModel : DomainModel, IAggregateRoot
    {
        public Author Author { get; }

        public RssFeedDomainModel(Author author)
        {
            Guard.ThrowIfNull(author, nameof(author));
            
            Author = author;
        }

        private void AddRssFeedDomainEvent(Author author)
        {
            var domainEvent = new RssFeedCreateDomainEvent(author);
            
            AddDomainEvent(domainEvent);
        }
    }
}