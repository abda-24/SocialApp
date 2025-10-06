namespace Shared.DataTransferObject.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? SourceId { get; set; }
        public int RecipientId { get; set; }
        public int? TriggeredByUserId { get; set; }
    }
}
