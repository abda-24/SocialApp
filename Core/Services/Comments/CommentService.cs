using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Presentation.Hubs;
using ServiceAbstraction;
using Shared.DataTransferObject.Comment;

namespace Services.Comments
{
    public class CommentService(IUnitOfWork _unitOfWork, IMapper _mapper, IHubContext<NotificationHub> _notificationHub) : ICommentService
    {
        public async Task<CommentDto> CreateCommentAsync(CreateCommentDto commentDto)
        {
            var repo = _unitOfWork.GetRepository<Comment, int>();
            var comment = _mapper.Map<Comment>(commentDto);
            await repo.AddAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            var createdComment = await repo.GetByIdAsync(comment.Id, q => q
               .Include(c => c.User)
               .Include(c => c.Replies));
            if (createdComment?.Post != null)
            {
                var postOwnerId = createdComment.Post.UserId; 
                var commenterName = createdComment.User?.Username ?? "Someone"; 

                await _notificationHub.Clients
                    .User(postOwnerId.ToString())
                    .SendAsync("ReceiveNotification", new
                    {
                        Type = "Comment",
                        Message = $"{commenterName} commented on your post 💬",
                        PostId = createdComment.Post.Id,
                        CommenterId = createdComment.UserId
                    });

               

            }
            return _mapper.Map<CommentDto>(createdComment);

        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Comment, int>();
             var comment =   await repo.GetByIdAsync(id);
            if (comment == null) return false;
            repo.RemoveAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync()
        {
            var repo = _unitOfWork.GetRepository<Comment, int>();
             var comments = await repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Comment, int>();
            var comment = await repo.GetByIdAsync(id);

            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<bool> UpdateCommentAsync(int id, UpdateCommentDto updateComment)
        {
            var repo = _unitOfWork.GetRepository<Comment, int>();
            var comment = await repo.GetByIdAsync(id);
            if(comment == null) return false;
            _mapper.Map<UpdateCommentDto>(comment);
            comment.UpdatedAt = DateTime.Now;
         await _unitOfWork.SaveChangesAsync();
            return true;

        }
    }
}
