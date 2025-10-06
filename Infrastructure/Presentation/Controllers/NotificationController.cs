using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Notification;

namespace Presentation.Controllers
{
    public class NotificationController(IServiceManger _serviceManger):BaseController
    {

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto dto)
        {
            var result = await _serviceManger.notificationService.CreateNotificationAsync(dto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var result = await _serviceManger.notificationService.GetAllNotificationsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var result = await _serviceManger.notificationService.GetNotificationByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var result = await _serviceManger.notificationService.MarkAsReadAsync(id);
            return Ok(new { success = result, message = "Notification marked as read" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var result = await _serviceManger.notificationService.DeleteNotificationAsync(id);
            return Ok(new { success = result, message = "Notification deleted successfully" });
        }

    }
}
