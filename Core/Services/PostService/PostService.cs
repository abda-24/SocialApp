using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using ServiceAbstraction;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObject.Post;


namespace Services.PostService
{
    public class PostService(IUnitOfWork _unitOfWork,IMapper _mapper) : IPostService
    {
        public async Task<PostDto> CreatePostAsync(CreatePostDto postDto)
        {
          var post= _mapper.Map<Post>(postDto);
            var repo =  _unitOfWork.GetRepository<Post, int>();
            await repo.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PostDto>(post);
        }


        public async Task<bool> DeletePostAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Post, int>();
            var post = await repo.GetByIdAsync(id);
            if (post == null) return false;

             repo.RemoveAsync(post);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var repo = _unitOfWork.GetRepository<Post, int>();

            var posts = await repo
                .GetAllAsync(include: q => q
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .Include(p => p.Comments));

            return _mapper.Map<IEnumerable<PostDto>>(posts);


        }

        public async Task<PostDto?> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Post, int>();
            var post = await repo.GetByIdAsync(id);
            return _mapper.Map<PostDto?>(post);
        }

        public async Task<bool> UpdatePostAsync(int id, UpdatePostDto postDto)
        {
            var repo = _unitOfWork.GetRepository<Post, int>();
            var existingPost = await repo.GetByIdAsync(id);
            if (existingPost == null) return false;

            _mapper.Map(postDto, existingPost);
            existingPost.UpdatedAt = DateTime.UtcNow;

             repo.UpdateAsync(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
