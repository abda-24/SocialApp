using Domain.Entities;
using Mapster;
using Shared.DataTransferObject.Comment;

namespace Services.MappingProfile
{
    public class CommentProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Comment, CommentDto>()
                       .Map(dest => dest.UserName, src => src.User.Username)
                       .Map(dest => dest.Replies, src => src.Replies);

            config.NewConfig<CreateCommentDto, Comment>();
            config.NewConfig<UpdateCommentDto, Comment>();
        }
    }
}
