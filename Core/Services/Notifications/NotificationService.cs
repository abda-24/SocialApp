using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using ServiceAbstraction;
using Shared.DataTransferObject.Notification;

namespace Services.Notifications
{
    public class NotificationService(IUnitOfWork _unitOfWork,IMapper _mapper) : INotificationService
    {
        public async Task<NotificationDto> CreateNotificationAsync(CreateNotificationDto createNotificationDto)
        {
            var repo = _unitOfWork.GetRepository<Notification,int>();
            var notification = _mapper.Map<Notification>(createNotificationDto);
            notification.CreatedAt = DateTime.UtcNow;
           await repo.AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<NotificationDto>(notification);


        }

        public async Task<bool> DeleteNotificationAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Notification, int>();
            var notification = await repo.GetByIdAsync(id);
            if (notification == null) throw new Exception("Notification not found");
            repo.RemoveAsync(notification);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync()
        {
            var repo = _unitOfWork.GetRepository<Notification, int>();
            var notifications = await repo.GetAllAsync();
            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }

        public async Task<NotificationDto> GetNotificationByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Notification,int>();
            var notifications = await repo.GetByIdAsync(id);
            if (notifications == null) throw new Exception("Notification not found");
          await  _unitOfWork.SaveChangesAsync();
            return _mapper.Map<NotificationDto>(notifications);

        }

        public async Task<bool> MarkAsReadAsync(int id)
        {

            var repo = _unitOfWork.GetRepository<Notification, int>();
            var notification = await repo.GetByIdAsync(id);
            if (notification == null) throw new Exception("Notification not found");
            notification.IsRead = true;
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
