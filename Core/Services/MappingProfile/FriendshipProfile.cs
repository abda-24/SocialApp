using Mapster;
using Shared.DataTransferObject.Friend;

namespace Services.MappingProfile
{
    public class FriendshipProfile:IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Friendship, FriendshipDto>()
                .Map(dest => dest.RequesterName, src => src.Requester.Username)
                .Map(dest => dest.ReceiverName, src => src.Receiver.Username);
        }
    }
}
