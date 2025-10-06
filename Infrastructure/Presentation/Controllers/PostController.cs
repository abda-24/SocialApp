using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Post;

namespace Presentation.Controllers
{
    public class PostController(IServiceManger  _serviceManger):BaseController
    {
        // GET: api/posts
        [HttpGet]

        public async Task<ActionResult<IEnumerable<PostDto>>>GetAllPosts()
        {
            var posts = await _serviceManger.PostService.GetAllPostsAsync();
            return Ok(posts);
        }
        // GET: api/posts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            var post = await _serviceManger.PostService.GetByIdAsync(id);
            return Ok(post);
        }
        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<CreatePostDto>> CreatePost(CreatePostDto postDto)
        {
            var post =await _serviceManger.PostService.CreatePostAsync(postDto);
            return Ok(post);
        }
        // PUT: api/posts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePostDto>>UpdatePost(int id,UpdatePostDto postDto)
        {
            var post = await _serviceManger.PostService.UpdatePostAsync(id,postDto);
            return Ok(post);
        }
        // DELETE: api/posts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _serviceManger.PostService.DeletePostAsync(id);
            return Ok(post);
        }

    }
}
