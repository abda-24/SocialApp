using Domain.Entities;
using Mapster;
using Shared.DataTransferObject.Message;

namespace Services.MappingProfile
{
    public class Message : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
           
            config.NewConfig<CreateMessageDto, Message>();
            config.NewConfig<Message, MessageDto>();

            
            config.NewConfig<ConversationDto, Conversation>();
            config.NewConfig<Conversation, ConversationDto>();

            
            config.NewConfig<NotificationDto, Notificationss>();
            config.NewConfig<Notificationss, NotificationDto>();

        }
    }
}
