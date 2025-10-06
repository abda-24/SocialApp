using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAbstraction;
using Shared.DataTransferObject.User;

namespace Services.Profile
{
    public class UserProfileService(IUnitOfWork _unitOfWork,IMapper _mapper) : IUserProfileService
    {
        public async Task<UserProfileDto> GetUserProfileAsync(int userId)
        {
            var userRepo = _unitOfWork.GetRepository<User, int>();

            var user = await userRepo.GetByIdAsync(
                userId,
                include: q => q
                    .Include(u => u.Posts)
                    .Include(u => u.SentFriendRequests)
                    .Include(u => u.Likes)
            );

            if (user == null)
                throw new Exception("User not found");

            var postsCount = user.Posts.Count;
            var friendsCount = user.ReceivedFriendRequests.Count(f => f.Status == FriendshipStatus.Accepted);
            var likesReceived = user.Posts.Sum(p => p.Likes.Count);

            return new UserProfileDto
            {
                Id = user.Id,
                UserName = user.Username,
                FullName = user.Username,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfilePictureUrl,
                PostsCount = postsCount,
                FriendsCount = friendsCount,
                LikesReceived = likesReceived,
                JoinedAt = user.CreatedAt
            };
        }

        public async Task<bool> UpdateUserProfileAsync(int userId, UpdateUserProfileDto updateProfile)
        {
            var userRepo = _unitOfWork.GetRepository<User, int>();
            var user = await userRepo.GetByIdAsync(userId);
            if (user == null) return false;

            user.Username = updateProfile.FullName ?? user.Username;
            user.Bio = updateProfile.Bio ?? user.Bio;
            user.ProfilePictureUrl = updateProfile.ProfileImageUrl ?? user.ProfilePictureUrl;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
