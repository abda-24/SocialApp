using Shared.DataTransferObject.Trending;

namespace ServiceAbstraction
{
    public interface IExploreService
    {
        Task<IEnumerable<TrendingPostDto>> GetTrendingPostsAsync();
    }
}
