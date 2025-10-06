namespace Shared.DataTransferObject.User
{
    public class UpdateUserProfileDto
    {
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
