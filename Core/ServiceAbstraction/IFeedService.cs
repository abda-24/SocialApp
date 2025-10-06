using Shared.DataTransferObject.Feed;

namespace ServiceAbstraction
{
    public interface IFeedService
    {
        Task<IEnumerable<FeedPostDto>> GetUserFeedAsync(int userId);

    }
}
