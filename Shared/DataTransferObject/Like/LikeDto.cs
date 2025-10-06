namespace Shared.DataTransferObject.Like
{
    public class LikeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
