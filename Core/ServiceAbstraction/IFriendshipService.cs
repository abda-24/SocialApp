using Shared.DataTransferObject.Friend;

namespace ServiceAbstraction
{
    public interface IFriendshipService
    {
        Task<FriendshipDto> SendFriendRequestAsync(int requesterId, CreateFriendRequestDto dto);
        Task<bool> AcceptFriendRequestAsync(int requestId);
        Task<bool> RemoveFriendAsync(int friendshipId);
        Task<IEnumerable<FriendshipDto>> GetFriendsAsync(int userId);
        Task<IEnumerable<FriendshipDto>> GetPendingRequestsAsync(int userId);
    }
}
