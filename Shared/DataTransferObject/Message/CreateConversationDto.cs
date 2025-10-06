namespace Shared.DataTransferObject.Message
{
    public class CreateConversationDto
    {
        public int Id { get; set; }
        public List<int> ParticipantIds { get; set; } = new();
    }
}
