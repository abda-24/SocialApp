using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;

namespace Presentation.Controllers
{
    public class SearchController(IServiceManger _serviceManger):BaseController
    {
        [HttpGet("users")]
        public async Task<IActionResult> SearchUsers( string query)
        {
            var users = await _serviceManger.searchService.SearchUsersAsync(query);
            return Ok(users);
        }
        [HttpGet("posts")]
        public async Task<IActionResult> SearchPosts( string query)
        {
            var posts = await _serviceManger.searchService.SearchPostsAsync(query);
            return Ok(posts);
        }
        [HttpGet("all")]
        public async Task<IActionResult> SearchAll( string query)
        {
            var result = await _serviceManger.searchService.SearchAllAsync(query);
            return Ok(result);
        }


    }
}
