using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;

namespace Presentation.Controllers
{
    public class FeedController(IServiceManger _serviceManger):BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserFeed(int userId)
        {
            var feed = await _serviceManger.feedService.GetUserFeedAsync(userId);
            return Ok(feed);
        }
    }
}
