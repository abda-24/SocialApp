using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Friend;

namespace Presentation.Controllers
{
    public class FriendshipController(IServiceManger _serviceManger):BaseController
    {
        // POST: /api/friends/{receiverId} → Send friend request
        [HttpPost("{receiverId}")]
        public async Task<IActionResult> SendFriendRequest(int receiverId, [FromBody] CreateFriendRequestDto dto)
        {
            var result = await _serviceManger.FriendshipService.SendFriendRequestAsync(receiverId, dto);
            return Ok(result);
        }
        [HttpPut("{id}/accept")]
        public async Task<IActionResult> AcceptFriendRequest(int id)
        {
            var result = await _serviceManger.FriendshipService.AcceptFriendRequestAsync(id);
            if (!result) return NotFound("Request not found or already processed.");
            return Ok("Friend request accepted.");
        }
        // DELETE: /api/friends/{id} → Remove friend
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFriend(int id)
        {
            var result = await _serviceManger.FriendshipService.RemoveFriendAsync(id);
            if (!result) return NotFound("Friendship not found.");
            return Ok("Friend removed successfully.");
        }
        // GET: /api/friends → Get all friends for user
        [HttpGet]
        public async Task<IActionResult> GetAllFriends([FromQuery] int userId)
        {
            var friends = await _serviceManger.FriendshipService.GetFriendsAsync(userId);
            return Ok(friends);
        }
        // GET: /api/friends/requests → Get pending requests
        [HttpGet("requests")]
        public async Task<IActionResult> GetPendingRequests([FromQuery] int userId)
        {
            var requests = await _serviceManger.FriendshipService.GetPendingRequestsAsync(userId);
            return Ok(requests);
        }
    }
}
