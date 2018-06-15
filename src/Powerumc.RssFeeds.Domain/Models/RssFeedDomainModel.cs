using Powerumc.RssFeeds.Domain.Events;
using Powerumc.RssFeeds.ValueObjects;

namespace Powerumc.RssFeeds.Domain.Models
{
    public class RssFeedDomainModel : DomainModel
    {
        private readonly Author _author;

        public RssFeedDomainModel(Author author)
        {
            _author = author;
        }

        private void AddRssFeedDomainEvent(Author author)
        {
            var domainEvent = new RssFeedCreateDomainEvent(author);
            
            AddDomainEvent(domainEvent);
        }
    }
}