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
    public class RssFeedCreateDomainEventHandler : IDomainEventHandler<RssFeedCreateDomainEvent>
    {
        private readonly TraceId _traceId;
        private readonly ILogger<RssFeedCreateDomainEventHandler> _logger;
        private readonly IRssFeedsRepository _rssFeedsRepository;

        public RssFeedCreateDomainEventHandler(TraceId traceId,
            ILogger<RssFeedCreateDomainEventHandler> logger,
            IRssFeedsRepository rssFeedsRepository)
        {
            _traceId = traceId;
            _logger = logger;
            _rssFeedsRepository = rssFeedsRepository;
        }

        public async Task Handle(RssFeedCreateDomainEvent @event)
        {
            _logger.Log(_traceId, @event.ToJson());

            await _rssFeedsRepository.CreateAsync(new RssFeed
            {
                Title = @event.Author.Title,
                Url = @event.Author.Url,
                CreateDate = DateTime.UtcNow,
                ModifyDate = DateTime.UtcNow
            });
        }
    }
}