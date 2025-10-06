
using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObject.File
{
    public class UploadFileDto
    {
        public IFormFile File { get; set; }
    }
}
