using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Powerumc.RssFeeds.Database.Models;
using Powerumc.RssFeeds.Domain;
using Powerumc.RssFeeds.Domain.Events;
using Powerumc.RssFeeds.Extensions;
using Powerumc.RssFeeds.Repositories;

namespace Powerumc.RssFeeds.Services.Handlers
{
    public class RssFeedCreatedDomainEventHandler : IDomainEventHandler<RssFeedCreatedDomainEvent>
    {
        private readonly TraceId _traceId;
        private readonly ILogger<RssFeedCreatedDomainEventHandler> _logger;
        private readonly IRssFeedsRepository _rssFeedsRepository;

        public RssFeedCreatedDomainEventHandler(TraceId traceId,
            ILogger<RssFeedCreatedDomainEventHandler> logger,
            IRssFeedsRepository rssFeedsRepository)
        {
            _traceId = traceId;
            _logger = logger;
            _rssFeedsRepository = rssFeedsRepository;
        }

        public async Task Handle(RssFeedCreatedDomainEvent @event)
        {
            _logger.Log(_traceId, @event.ToJson());

            await _rssFeedsRepository.CreateAsync(new RssFeed
            {
                Title = @event.Author.Title,
                Url = @event.Author.Url,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            });
        }
    }
}