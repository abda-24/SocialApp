using Domain.Entities;
using Domain.Interfaces; // Assuming IServiceManager and other interfaces are here
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DataTransferObject.Register;
using Shared.DataTransferObject.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return new AuthResponseDto { IsSuccess = false, Message = "Email is already taken." };
            }

            var user = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                // You can map other properties like FirstName, LastName here if they exist
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthResponseDto { IsSuccess = false, Message = errors };
            }

            // Assign a default role to the new user
            await _userManager.AddToRoleAsync(user, "User");

            var token = await GenerateJwtToken(user);
            return new AuthResponseDto { IsSuccess = true, Token = token };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            // Allow login with either username or email
            var user = await _userManager.FindByEmailAsync(dto.Email) ?? await _userManager.FindByNameAsync(dto.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                return new AuthResponseDto { IsSuccess = false, Message = "Invalid email or password." };
            }

            var token = await GenerateJwtToken(user);
            return new AuthResponseDto { IsSuccess = true, Token = token };
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<GenericResponse> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // For security, don't reveal that the user doesn't exist.
                return new GenericResponse { IsSuccess = true, Message = "If an account with this email exists, a password reset link has been sent." };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // IMPORTANT: Here you should implement your email sending logic.
            // For example: await _emailService.SendPasswordResetEmailAsync(user.Email, token);
            // For now, we just print it to the console for development/testing.
            System.Diagnostics.Debug.WriteLine($"Password Reset Token for {user.Email}: {token}");

            return new GenericResponse { IsSuccess = true, Message = "If an account with this email exists, a password reset link has been sent." };
        }

        public async Task<GenericResponse> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return new GenericResponse { IsSuccess = false, Message = "Password reset failed. Invalid request." };
            }

            // The token from the DTO needs to be decoded if it was URL-encoded
            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(" ", result.Errors.Select(e => e.Description));
                return new GenericResponse { IsSuccess = false, Message = $"Password reset failed: {errors}" };
            }

            return new GenericResponse { IsSuccess = true, Message = "Password has been reset successfully." };
        }

        public async Task<UserDto?> GetCurrentUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return null;
            }

            var userDto = _mapper.Map<UserDto>(user);
            // You might want to include roles in the UserDto
            return userDto;
        }

        public async Task<bool> AssignRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return false;
            }

            // You might want to check if the role exists first
            // var roleExists = await _roleManager.RoleExistsAsync(roleName);
            // if (!roleExists) return false;

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public Task LogoutAsync()
        {
            // For stateless JWT, logout is a client-side responsibility (deleting the token).
            // If you implement a token blacklist, the logic to add the token to the blacklist would go here.
            return Task.CompletedTask;
        }

        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]!);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName!)
            };

            // Add role claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JwtSettings:DurationInHours"] ?? "1")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
