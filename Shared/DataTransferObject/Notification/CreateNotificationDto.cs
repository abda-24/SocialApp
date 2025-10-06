namespace Shared.DataTransferObject.Notification
{
    public class CreateNotificationDto
    {
        public string Type { get; set; } // Like, Comment, FriendRequest
        public int RecipientId { get; set; }
        public int? TriggeredByUserId { get; set; }
        public int? SourceId { get; set; }

    }
}
