using Shared.DataTransferObject.Comment;

namespace ServiceAbstraction
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllCommentsAsync();
        Task<CommentDto> GetCommentByIdAsync(int id);
        Task<CommentDto> CreateCommentAsync(CreateCommentDto commentDto);
        Task<bool> UpdateCommentAsync(int id, UpdateCommentDto updateComment);
        Task<bool> DeleteCommentAsync(int id);
    }
}
