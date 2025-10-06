using Microsoft.AspNetCore.SignalR;

namespace Presentation.Hubs
{
    public class NotificationHub:Hub
    {
        
        public async Task JoinUserGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

       
        public async Task LeaveUserGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }

      
        public async Task SendNotification(string userId, string message)
        {
            await Clients.Group(userId).SendAsync("ReceiveNotification", message);
        }
    }
}
