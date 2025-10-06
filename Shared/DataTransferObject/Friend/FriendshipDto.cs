namespace Shared.DataTransferObject.Friend
{
    public class FriendshipDto
    {
        public int Id { get; set; }
        public int RequesterId { get; set; }
        public string RequesterName { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string Status { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? RespondedAt { get; set; }
    }
}
