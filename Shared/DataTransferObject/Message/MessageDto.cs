namespace Shared.DataTransferObject.Message
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public int SenderId { get; set; }
        public int ConversationId { get; set; }
    }
}
