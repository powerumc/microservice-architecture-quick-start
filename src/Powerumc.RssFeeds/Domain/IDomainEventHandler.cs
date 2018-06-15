using System.Threading.Tasks;

namespace Powerumc.RssFeeds.Domain
{
    public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task Handle(TDomainEvent @event);
    }
}