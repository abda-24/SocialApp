using Shared.DataTransferObject.Post;

namespace ServiceAbstraction
{
    public interface IPostService
    {
        // ✅ Get all posts
        Task<IEnumerable<PostDto>> GetAllPostsAsync();

        // ✅ Get single post by ID
        Task<PostDto?> GetByIdAsync(int id);

        // ✅ Create new post
        Task<PostDto> CreatePostAsync(CreatePostDto postDto);

        Task<bool> UpdatePostAsync(int id, UpdatePostDto postDto);

        // ✅ Delete post by ID
        Task<bool> DeletePostAsync(int id);
    }
}
