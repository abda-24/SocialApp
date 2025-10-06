using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAbstraction;
using Shared.DataTransferObject.Feed;

namespace Services.Feed
{
    public class FeedService(IUnitOfWork _unitOfWork, IMapper _mapper) : IFeedService
    {
        public async Task<IEnumerable<FeedPostDto>> GetUserFeedAsync(int userId)
        {
            var friendshipRepo = _unitOfWork.GetRepository<Friendship, int>();
            var friendships = await friendshipRepo.GetAllAsync(f =>
                f.Status == FriendshipStatus.Accepted &&
                (f.RequesterId == userId || f.ReceiverId == userId)
            );

            var ids = friendships
                .Select(f => f.RequesterId == userId ? f.ReceiverId : f.RequesterId)
                .Append(userId) 
                .ToList();

            var postRepo = _unitOfWork.GetRepository<Post, int>();
            var posts = await postRepo.GetAllAsync(
                p => ids.Contains(p.UserId),
                include: q => q
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .Include(p => p.Comments)
                    .OrderByDescending(p => p.CreatedAt)
            );

            return posts.Select(p => new FeedPostDto
            {
                Id = p.Id,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                CreatedAt = p.CreatedAt,
                AuthorId = p.UserId,
                AuthorName = p.User?.Username ?? "",
                AuthorProfileImage = p.User?.ProfilePictureUrl,
                LikesCount = p.Likes?.Count ?? 0,
                CommentsCount = p.Comments?.Count ?? 0
            });
        }
    }
}
