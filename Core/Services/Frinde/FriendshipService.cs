using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Presentation.Hubs;
using ServiceAbstraction;
using Shared.DataTransferObject.Friend;

namespace Services.Friends
{
    public class FriendshipService(IUnitOfWork _unitOfWork, IMapper _mapper, IHubContext<NotificationHub> _notificationHub)
        : IFriendshipService
    {
        public async Task<FriendshipDto> SendFriendRequestAsync(int requesterId, CreateFriendRequestDto dto)
        {
            var repo = _unitOfWork.GetRepository<Friendship, int>();

            var friendship = new Friendship()
            {
                RequesterId = requesterId,
                ReceiverId = dto.ReceiverId,
                Status = FriendshipStatus.Pending
            };

            await repo.AddAsync(friendship);
            await _unitOfWork.SaveChangesAsync();

            var createdFriendshipWithUsers = await repo.GetByIdAsync(
                friendship.Id,
                include: q => q.Include(f => f.Requester)
                               .Include(f => f.Receiver)
            );

            await _notificationHub.Clients
                .User(dto.ReceiverId.ToString()) // اللي جاله الريكوست
                .SendAsync("ReceiveNotification", new
                {
                    Type = "FriendRequest",
                    Message = "You have a new friend request 👥",
                    FromUserId = requesterId
                });

            return _mapper.Map<FriendshipDto>(createdFriendshipWithUsers);
        }

        public async Task<bool> AcceptFriendRequestAsync(int requestId)
        {
            var repo = _unitOfWork.GetRepository<Friendship, int>();
            var request = await repo.GetByIdAsync(requestId);

            if (request == null || request.Status != FriendshipStatus.Pending)
                return false;

            request.Status = FriendshipStatus.Accepted;
            request.RespondedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

           
            await _notificationHub.Clients
                .User(request.RequesterId.ToString())
                .SendAsync("ReceiveNotification", new
                {
                    Type = "FriendAccepted",
                    Message = "Your friend request has been accepted ✅",
                    FromUserId = request.ReceiverId
                });

            return true;
        }

        public async Task<bool> RemoveFriendAsync(int friendshipId)
        {
            var repo = _unitOfWork.GetRepository<Friendship, int>();
            var friendship = await repo.GetByIdAsync(friendshipId);
            if (friendship == null) return false;

             repo.RemoveAsync(friendship);
            await _unitOfWork.SaveChangesAsync();

            await _notificationHub.Clients
                .User(friendship.RequesterId.ToString())
                .SendAsync("ReceiveNotification", new
                {
                    Type = "FriendRemoved",
                    Message = "You are no longer friends ❌",
                });

            await _notificationHub.Clients
                .User(friendship.ReceiverId.ToString())
                .SendAsync("ReceiveNotification", new
                {
                    Type = "FriendRemoved",
                    Message = "You are no longer friends ❌",
                });

            return true;
        }

        public async Task<IEnumerable<FriendshipDto>> GetFriendsAsync(int userId)
        {
            var repo = _unitOfWork.GetRepository<Friendship, int>();

            var friends = await repo.GetAllAsync(
                f => f.Status == FriendshipStatus.Accepted &&
                     (f.RequesterId == userId || f.ReceiverId == userId),
                include: q => q.Include(f => f.Requester)
                               .Include(f => f.Receiver)
            );

            return _mapper.Map<IEnumerable<FriendshipDto>>(friends);
        }

        public async Task<IEnumerable<FriendshipDto>> GetPendingRequestsAsync(int userId)
        {
            var repo = _unitOfWork.GetRepository<Friendship, int>();
            var requests = await repo.GetAllAsync(
                f => f.Status == FriendshipStatus.Pending && f.ReceiverId == userId,
                include: q => q.Include(f => f.Requester)
                               .Include(f => f.Receiver)
            );

            return _mapper.Map<IEnumerable<FriendshipDto>>(requests);
        }
    }
}
