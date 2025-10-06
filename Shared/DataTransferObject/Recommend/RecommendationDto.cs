namespace Shared.DataTransferObject.Recommend
{
    public class RecommendationDto
    {
        public IEnumerable<RecommendedPostDto>? RecommendedPosts { get; set; }
        public IEnumerable<RecommendedUserDto>? RecommendedUsers { get; set; }
    }
}
