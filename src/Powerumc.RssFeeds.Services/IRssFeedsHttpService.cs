using System.Threading.Tasks;

namespace Powerumc.RssFeeds.Services
{
    public interface IRssFeedsHttpService
    {
        Task<Domain.Responses.V1.RssFeedItemResponse> AllItemsAsync();
    }
}