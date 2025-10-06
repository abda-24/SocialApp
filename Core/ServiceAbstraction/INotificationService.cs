using Shared.DataTransferObject.Notification;

namespace ServiceAbstraction
{
    public interface INotificationService
    {
        Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto createNotificationDto);
        Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync();
        Task<NotificationDto> GetNotificationByIdAsync(int id);
        Task<bool> MarkAsReadAsync(int id);
        Task<bool> DeleteNotificationAsync(int id);
    }
}
