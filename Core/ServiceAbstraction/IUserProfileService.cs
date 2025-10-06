using Shared.DataTransferObject.User;

namespace ServiceAbstraction
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> GetUserProfileAsync(int userId);
        Task<bool> UpdateUserProfileAsync(int userId, UpdateUserProfileDto updateProfile);
    }
}
