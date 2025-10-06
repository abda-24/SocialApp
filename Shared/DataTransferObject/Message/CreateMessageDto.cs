namespace Shared.DataTransferObject.Message
{
    public class CreateMessageDto
    {
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int ConversationId { get; set; }
    }
}
