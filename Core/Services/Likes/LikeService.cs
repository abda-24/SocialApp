using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using ServiceAbstraction;
using Shared.DataTransferObject.Like;
using Microsoft.EntityFrameworkCore;
using Presentation.Hubs;
using Microsoft.AspNetCore.SignalR;


namespace Services.Likes
{
    public class LikeService(IUnitOfWork _unitOfWork, IMapper _mapper, IHubContext<NotificationHub> _notificationHub) : ILikeService
    {
        public async Task<LikeDto> CreateLikeAsync(CreateLikeDto likeDto)
        {
            var repo = _unitOfWork.GetRepository<Like, int>();

            var like = _mapper.Map<Like>(likeDto);

            await repo.AddAsync(like);
            await _unitOfWork.SaveChangesAsync();

            var createdLike = await repo.GetByIdAsync(like.Id, include: q => q
                .Include(l => l.User)
                .Include(l => l.Post));
            if (createdLike?.Post != null)
            {
                var postOwnerId = createdLike.Post.UserId; 
                var likerName = createdLike.User?.Username ?? "Someone"; 

                await _notificationHub.Clients
                    .User(postOwnerId.ToString())
                    .SendAsync("ReceiveNotification", new
                    {
                        Type = "Like",
                        Message = $"{likerName} liked your post ❤️",
                        PostId = createdLike.Post.Id,
                        LikerId = createdLike.UserId
                    });
            }

            return _mapper.Map<LikeDto>(createdLike);
        }

        public async Task<bool> DeleteLikeAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Like, int>();
            var like = await repo.GetByIdAsync(id);
            if (like == null) return false;

            repo.RemoveAsync(like);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LikeDto>> GetAllLikesAsync()
        {
            var repo = _unitOfWork.GetRepository<Like, int>();
            var likes = await repo.GetAllAsync(include: q => q
                .Include(l => l.User)
                .Include(l => l.Post));

            return _mapper.Map<IEnumerable<LikeDto>>(likes);
        }

        public async Task<LikeDto?> GetLikeByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Like, int>();
            var like = await repo.GetByIdAsync(id, include: q => q
                .Include(l => l.User)
                .Include(l => l.Post));

            return _mapper.Map<LikeDto?>(like);
        }
    }
}
