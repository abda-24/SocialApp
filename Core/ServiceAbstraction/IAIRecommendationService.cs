using Shared.DataTransferObject.Recommend;

namespace ServiceAbstraction
{
    public interface IAIRecommendationService
    {
        
        Task<IEnumerable<RecommendedPostDto>> GetRecommendedPostsAsync(int userId);

        
        Task<IEnumerable<RecommendedUserDto>> GetRecommendedUsersAsync(int userId);

        Task<RecommendationDto> GetFullRecommendationFeedAsync(int userId);
    }
}
