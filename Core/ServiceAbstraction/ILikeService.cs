using Shared.DataTransferObject.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ILikeService
    {
        Task<IEnumerable<LikeDto>> GetAllLikesAsync();
        Task<LikeDto?> GetLikeByIdAsync(int id);
        Task<LikeDto> CreateLikeAsync(CreateLikeDto likeDto);
        Task<bool> DeleteLikeAsync(int id);
    }
}
