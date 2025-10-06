using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Like;

namespace Presentation.Controllers
{
    public class LikesController(IServiceManger _serviceManger):BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetAllLikes()
        {
            var likes = await _serviceManger.LikeService.GetAllLikesAsync();
            return Ok(likes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LikeDto?>> GetLikeById(int id)
        {
            var like = await _serviceManger.LikeService.GetLikeByIdAsync(id);
           
            return Ok(like);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CreateLikeDto>>> CreateLike(CreateLikeDto createLikeDto)
        {
            var Like = await _serviceManger.LikeService.CreateLikeAsync(createLikeDto);
            return Ok(Like);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLike(int id)
        {
            var result = await _serviceManger.LikeService.DeleteLikeAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }




    }
}
