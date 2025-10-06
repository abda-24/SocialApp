using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Comment;

namespace Presentation.Controllers
{
    public class CommentsController(IServiceManger _serviceManger):BaseController
    {
        [HttpGet]
       public async Task<ActionResult<IEnumerable<CommentDto>>> GetAllComments()
        {
            var comment = await _serviceManger.CommentService.GetAllCommentsAsync();
            return Ok(comment);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetCommentById(int id)
        {
            var comment = await _serviceManger.CommentService.GetCommentByIdAsync(id);
            return Ok(comment);
        }
        [HttpPost]
        public async Task<ActionResult<CommentDto>> CreateComment(CreateCommentDto createCommentDto)
        {
            var comment = await _serviceManger.CommentService.CreateCommentAsync(createCommentDto);
            return Ok(comment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCommentDto>> UpdateComment(int id, UpdateCommentDto updateCommentDto)
        {
            var comment = await _serviceManger.CommentService.UpdateCommentAsync(id,updateCommentDto);
            return Ok(comment);

        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id )
        {
            var comment = await _serviceManger.CommentService.DeleteCommentAsync(id);
            return Ok(comment);
        }

    }
}
