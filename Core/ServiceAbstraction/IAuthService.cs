using Shared.DataTransferObject.Register;
using Shared.DataTransferObject.User;

namespace ServiceAbstraction
{
    public interface IAuthService
    {
        // --- Existing Methods ---
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task<UserDto?> GetCurrentUserAsync(string userId);
        Task<bool> AssignRoleAsync(string userId, string roleName);
        Task LogoutAsync(); // This might be conceptual for JWT

        // --- New Methods ---
        Task<bool> CheckEmailExistsAsync(string email);
        Task<GenericResponse> ForgotPasswordAsync(string email);
        Task<GenericResponse> ResetPasswordAsync(ResetPasswordDto dto);
    }
}
