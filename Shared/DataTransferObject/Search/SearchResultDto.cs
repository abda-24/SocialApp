using Shared.DataTransferObject.Post;
using Shared.DataTransferObject.User;

namespace Shared.DataTransferObject.Search
{
    public class SearchResultDto
    {
        public IEnumerable<UserDto>? Users { get; set; }
        public IEnumerable<PostDto>? Posts { get; set; }
    }
}
