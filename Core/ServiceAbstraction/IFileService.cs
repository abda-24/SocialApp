using Shared.DataTransferObject.File;

namespace ServiceAbstraction
{
    public interface IFileService
    {
        Task<FileResponseDto> UploadAsync(UploadFileDto dto);
        Task<FileResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<FileResponseDto>> GetAllAsync(); 
        Task<bool> DeleteAsync(int id);

    }
}
