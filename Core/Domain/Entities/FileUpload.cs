using Domain.Common;

namespace Domain.Entities
{
    public class FileUpload:BaseEntity<int>
    {
        public int Id { get; set; }
        public string FileName { get; set; }    
        public string FileUrl { get; set; }    
        public string ContentType { get; set; }  
        public long Size { get; set; }           
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
