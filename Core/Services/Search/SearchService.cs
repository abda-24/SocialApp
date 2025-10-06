using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using ServiceAbstraction;
using Shared.DataTransferObject.Post;
using Shared.DataTransferObject.Search;
using Shared.DataTransferObject.User;

namespace Services.Search
{
    public class SearchService(IUnitOfWork _unitOfWork,IMapper _mapper) : ISearchService
    {
        public async Task<SearchResultDto> SearchAllAsync(string query)
        {
            var users = await SearchUsersAsync(query);
            var posts = await SearchPostsAsync(query);

            return new SearchResultDto
            {
                Users = users,
                Posts = posts
            };
        }

        public async Task<IEnumerable<PostDto>> SearchPostsAsync(string query)
        {
            var repo = _unitOfWork.GetRepository<Post, int>();
            var posts = await repo.GetAllAsync(p =>
                p.Content.Contains(query) || p.Content.Contains(query));
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<IEnumerable<UserDto>> SearchUsersAsync(string query)
        {
            var repo = _unitOfWork.GetRepository<User, int>();
            var users = await repo.GetAllAsync(u =>
                u.Username.Contains(query) || u.Username.Contains(query));
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
