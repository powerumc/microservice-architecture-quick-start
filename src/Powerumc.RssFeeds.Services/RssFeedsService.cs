using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Powerumc.RssFeeds.Database.Models;
using Powerumc.RssFeeds.Domain;
using Powerumc.RssFeeds.Domain.Models;
using Powerumc.RssFeeds.Domain.Responses.V1;
using Powerumc.RssFeeds.Repositories;
using Powerumc.RssFeeds.Services.Handlers;
using Powerumc.RssFeeds.ValueObjects;

namespace Powerumc.RssFeeds.Services
{
    [Register(typeof(IRssFeedsService))]
    public class RssFeedsService : IRssFeedsService
    {
        private readonly TraceId _traceId;
        private readonly ILogger<RssFeedsService> _logger;
        private readonly IRssFeedsRepository _repository;

        public RssFeedsService(TraceId traceId,
            ILogger<RssFeedsService> logger,
            IRssFeedsRepository repository)
        {
            _traceId = traceId;
            _logger = logger;
            _repository = repository;
        }

        public async Task<PagingResult<IEnumerable<Domain.Responses.V1.RssFeedResponse>>> ListAsync(
            Expression<Func<Database.Models.RssFeed, bool>> expression, PagingInfo pagingInfo)
        {
            var result = await _repository.List(expression, pagingInfo);

            return await Task.FromResult(new PagingResult<IEnumerable<Domain.Responses.V1.RssFeedResponse>>
            {
                TotalCount = result.TotalCount,
                Results = result.Results.Select(ConvertFrom)
            });
        }

        public async Task<Domain.Responses.V1.RssFeedResponse> CreateAsync(
            Domain.Requests.V1.RssFeedCreateRequest request)
        {
            Guard.ThrowIfNull(request, nameof(request));
            Guard.ThrowIfNullOrWhitespace(request.Title, nameof(request.Title));
            Guard.ThrowIfNullOrWhitespace(request.Url, nameof(request.Url));
            
            var entity = await _repository.CreateAsync(new RssFeed
            {
                Title = request.Title,
                Url = request.Url,
                CreateDate = DateTime.UtcNow,
                ModifyDate = DateTime.UtcNow
            });

            var result = await _repository.GetAsync(entity.Id);

            return await Task.FromResult(ConvertFrom(result));
        }

        private static Domain.Responses.V1.RssFeedResponse ConvertFrom(Database.Models.RssFeed model)
        {
            return new RssFeedResponse
            {
                Id = model.Id,
                Title = model.Title,
                Url = model.Url,
                CreateDate = model.CreateDate,
                ModifyDate = model.ModifyDate
            };
        }
    }
}