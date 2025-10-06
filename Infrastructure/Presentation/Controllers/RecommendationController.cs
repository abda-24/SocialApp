using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Recommend;

namespace Presentation.Controllers
{
    public class RecommendationController(IServiceManger _serviceManger):BaseController
    {
        [HttpGet("posts/{userId}")]
        public async Task<ActionResult<IEnumerable<RecommendedPostDto>>> GetRecommendedPosts(int userId)
        {
            var result = await _serviceManger.aIRecommendationService.GetRecommendedPostsAsync(userId);
            return Ok(result);
           
        }

        
        [HttpGet("users/{userId}")]
        public async Task<ActionResult<IEnumerable<RecommendedUserDto>>> GetRecommendedUsers(int userId)
        {
            var result = await _serviceManger.aIRecommendationService.GetRecommendedUsersAsync(userId);
            return Ok(result);
            
        }


        [HttpGet("feed/{userId}")]
        public async Task<ActionResult<RecommendationDto>> GetFullRecommendationFeed(int userId)
        {
            var result = await _serviceManger.aIRecommendationService.GetFullRecommendationFeedAsync(userId);
            return Ok(result);
        }
    }
}
