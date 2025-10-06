using Shared.DataTransferObject.Post;
using Shared.DataTransferObject.Search;
using Shared.DataTransferObject.User;

namespace ServiceAbstraction
{
    public interface ISearchService
    {
        Task<IEnumerable<UserDto>> SearchUsersAsync(string query);
        Task<IEnumerable<PostDto>> SearchPostsAsync(string query);
        Task<SearchResultDto> SearchAllAsync(string query);
    }
}
