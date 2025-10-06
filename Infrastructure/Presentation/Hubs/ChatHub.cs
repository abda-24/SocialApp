using Microsoft.AspNetCore.SignalR;

namespace Presentation.Hubs
{
    public class ChatHub : Hub
    {
       
        public async Task JoinConversation(string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
        }

      
        public async Task LeaveConversation(string conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId);
        }

       
        public async Task SendMessage(string conversationId, string senderId, string message)
        {
            await Clients.Group(conversationId)
                .SendAsync("ReceiveMessage", senderId, message);
        }

     
        public async Task Typing(string conversationId, string userId)
        {
            await Clients.OthersInGroup(conversationId)
                .SendAsync("UserTyping", userId);
        }

        
        public async Task MessageRead(string conversationId, string messageId, string userId)
        {
            await Clients.Group(conversationId)
                .SendAsync("MessageRead", messageId, userId);
        }

        
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserOnline", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

       
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("UserOffline", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
