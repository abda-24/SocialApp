using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAbstraction;
using Shared.DataTransferObject.Trending;

namespace Services.Explore
{
    public class ExploreService(IUnitOfWork _unitOfWork, IMapper _mapper) : IExploreService
    {
        public async Task<IEnumerable<TrendingPostDto>> GetTrendingPostsAsync()
        {
            var postRepo = _unitOfWork.GetRepository<Post, int>();

            
            var posts = await postRepo.GetAllAsync(
                include: q => q
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .Include(p => p.Comments)
            );

            var trendingPosts = posts
                .OrderByDescending(p => (p.Likes.Count + p.Comments.Count))
                .Take(20) 
                .ToList();

            return trendingPosts.Select(p => new TrendingPostDto
            {
                Id = p.Id,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                CreatedAt = p.CreatedAt,
                AuthorImage = p.ImageUrl,
                AuthorName = p.User?.Username,
                LikesCount = p.Likes?.Count ?? 0,
                CommentsCount = p.Comments?.Count ?? 0
            });
        }
    }
}
