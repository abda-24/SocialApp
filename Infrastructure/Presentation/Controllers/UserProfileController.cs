using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.User;

namespace Presentation.Controllers
{
    public class UserProfileController(IServiceManger _serviceManger):BaseController
    {

       
            [HttpGet("{userId}")]
            public async Task<IActionResult> GetUserProfile(int userId)
            {
                var result = await _serviceManger.userProfileService.GetUserProfileAsync(userId);
                return Ok(result);
            }

            [HttpPut("{userId}")]
            public async Task<IActionResult> UpdateUserProfile(int userId, [FromBody] UpdateUserProfileDto dto)
            {
                var success = await _serviceManger.userProfileService.UpdateUserProfileAsync(userId, dto);
                if (!success) return NotFound("User not found");
                return Ok(new { message = "Profile updated successfully ✅" });
            }
        }
    }

