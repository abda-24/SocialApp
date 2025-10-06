using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Trending;

namespace Presentation.Controllers
{
    public class ExploreController(IServiceManger _serviceManger):BaseController
    {
        // GET: api/Explore/trending
        [HttpGet("trending")]
        public async Task<ActionResult<IEnumerable<TrendingPostDto>>> GetTrendingPosts()
        {
            var trendingPosts = await _serviceManger.exploreService.GetTrendingPostsAsync();
            return Ok(trendingPosts);
        }
    }
}
