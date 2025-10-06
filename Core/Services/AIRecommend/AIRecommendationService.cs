using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAbstraction;
using Shared.DataTransferObject.Recommend;

namespace Services.Recommendation
{
    public class AIRecommendationService(IUnitOfWork _unitOfWork, IMapper _mapper) : IAIRecommendationService
    {
        public async Task<IEnumerable<RecommendedPostDto>> GetRecommendedPostsAsync(int userId)
        {
            var postRepo = _unitOfWork.GetRepository<Post, int>();

            var friendshipRepo = _unitOfWork.GetRepository<Friendship, int>();
            var userFriendships = await friendshipRepo.GetAllAsync(f =>
                f.Status == FriendshipStatus.Accepted &&
                (f.RequesterId == userId || f.ReceiverId == userId)
            );

            var friendIds = userFriendships
                .Select(f => f.RequesterId == userId ? f.ReceiverId : f.RequesterId)
                .ToList();

            var posts = await postRepo.GetAllAsync(
                p => !friendIds.Contains(p.UserId) && p.UserId != userId,
                include: q => q.Include(p => p.User).Include(p => p.Likes).Include(p => p.Comments)
            );

            var random = new Random();
            posts = posts.OrderBy(x => random.Next()).Take(5).ToList();

            return posts.Select(p => new RecommendedPostDto
            {
                Id = p.Id,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                CreatedAt = p.CreatedAt,
                AuthorId = p.UserId,
                AuthorName = p.User.Username ?? "",
                AuthorProfileImage = p.User.ProfilePictureUrl ?? "",
                LikesCount = p.Likes?.Count ?? 0,
                CommentsCount = p.Comments?.Count ?? 0
            });
        }

        public async Task<IEnumerable<RecommendedUserDto>> GetRecommendedUsersAsync(int userId)
        {
            var userRepo = _unitOfWork.GetRepository<User, int>();
            var friendshipRepo = _unitOfWork.GetRepository<Friendship, int>();

            var friendships = await friendshipRepo.GetAllAsync(f =>
                f.Status == FriendshipStatus.Accepted &&
                (f.RequesterId == userId || f.ReceiverId == userId)
            );

            var friendIds = friendships
                .Select(f => f.RequesterId == userId ? f.ReceiverId : f.RequesterId)
                .Append(userId) 
                .ToList();

            var users = await userRepo.GetAllAsync(u => !friendIds.Contains(u.Id));

            var random = new Random();
            users = users.OrderBy(x => random.Next()).Take(5).ToList();

            return users.Select(u => new RecommendedUserDto
            {
                Id = u.Id,
                UserName = u.Username ?? "",
                ProfileImageUrl = u.ProfilePictureUrl ?? "",
               
            });
        }

        public async Task<RecommendationDto> GetFullRecommendationFeedAsync(int userId)
        {
            var posts = await GetRecommendedPostsAsync(userId);
            var users = await GetRecommendedUsersAsync(userId);

            return new RecommendationDto
            {
                RecommendedPosts = posts.ToList(),
                RecommendedUsers = users.ToList()
            };
        }
    }
}
