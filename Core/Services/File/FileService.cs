using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;
using ServiceAbstraction;
using Shared.DataTransferObject.File;

namespace Services.File
{
    public class FileService(IUnitOfWork _unitOfWork,IMapper _mapper, IWebHostEnvironment _env) : IFileService
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".mp4", ".pdf" };
        private const long _maxFileSize = 5 * 1024 * 1024;

        public async Task<IEnumerable<FileResponseDto>> GetAllAsync()
        {
            var files = await _unitOfWork.GetRepository<FileUpload,int>().GetAllAsync();
            return _mapper.Map<IEnumerable<FileResponseDto>>(files);
        }

        public async Task<FileResponseDto> GetByIdAsync(int id)
        {
            var file = await _unitOfWork.GetRepository<FileUpload, int>().GetByIdAsync(id);
            if (file == null)
                throw new Exception("File not found.");

            return _mapper.Map<FileResponseDto>(file);
        }

        public async Task<FileResponseDto> UploadAsync(UploadFileDto dto)
        {
            var repo = _unitOfWork.GetRepository<FileUpload, int>();
            var file = dto.File;
            if(file == null || file.Length == 0) throw new Exception("No file uploaded.");
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!_allowedExtensions.Contains(extension))
                throw new Exception("File type not allowed. Allowed: jpg, png, mp4, pdf.");
            if (file.Length > _maxFileSize)
                throw new Exception("File too large. Max size is 5MB.");
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + extension;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"/uploads/{fileName}";

            var entity = new FileUpload
            {
                FileName = fileName,
                FileUrl = fileUrl,
                ContentType = file.ContentType,
                Size = file.Length
            };

             await repo.AddAsync(entity);
           await  _unitOfWork.SaveChangesAsync();

            return _mapper.Map<FileResponseDto>(entity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<FileUpload, int>();
            var file = await repo.GetByIdAsync(id);
            if (file == null) return false;

            
            repo.RemoveAsync(file);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
