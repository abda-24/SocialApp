using Mapster;
using Shared.DataTransferObject.Notification;

namespace Services.MappingProfile
{
    public class Notificationss : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateNotificationDto, Notificationss>();
            config.NewConfig<Notificationss, NotificationDto>();
        }
    }
}
