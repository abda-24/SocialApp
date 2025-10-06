using Domain.Entities;
using Mapster;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObject.Post;
using Shared.DataTransferObject.User;

namespace Services.MappingProfile
{
    public class PostMappingConfig : IRegister
    {
        private readonly ImageUrlResolver _imageUrlResolver;

        public PostMappingConfig(IConfiguration _configuration)
        {
            _imageUrlResolver = new ImageUrlResolver(_configuration);
        }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Post, PostDto>()
                .Map(dest => dest.Author, src => src.User)
                .Map(dest => dest.LikesCount, src => src.Likes != null ? src.Likes.Count : 0)
                .Map(dest => dest.CommentsCount, src => src.Comments != null ? src.Comments.Count : 0)
                .Map(dest => dest.ImageUrl, src => _imageUrlResolver.Resolve(src.ImageUrl))
 
                   .Map(dest => dest.Author, src => src.User);

            config.NewConfig<User, UserDto>();
            config.NewConfig<CreatePostDto, Post>();
            config.NewConfig<UpdatePostDto, Post>();
        }
    }
}
