using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.File;

namespace Presentation.Controllers
{
    public class FileController(IServiceManger _serviceManger):BaseController
    {

    
            
            [HttpPost("upload")]
            public async Task<IActionResult> Upload([FromForm] UploadFileDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _serviceManger.fileService.UploadAsync(dto);
                return Ok(result);
            }

            
            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _serviceManger.fileService.GetByIdAsync(id);
                if (result == null)
                    return NotFound(new { message = "File not found ❌" });

                return Ok(result);
            }

            
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _serviceManger.fileService.GetAllAsync();
                return Ok(result);
            }

           
            [HttpDelete("{id:int}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _serviceManger.fileService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = "File not found ❌" });

                return Ok(new { message = "File deleted successfully ✅" });
            }
        }
}
