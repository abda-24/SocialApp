using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Message;

namespace Presentation.Controllers
{
    public class ConversationController(IServiceManger _serviceManager) :BaseController
    {
        // ✅ POST: /api/conversations
        [HttpPost]
        public async Task<IActionResult> CreateConversation( CreateConversationDto dto)
        {
            if (dto == null || dto.ParticipantIds == null || dto.ParticipantIds.Count == 0)
                return BadRequest("Participants are required.");

            var result = await _serviceManager.conversationService.CreateConversationAsync(dto);
            return Ok(result);
        }

        // ✅ GET: /api/conversations
        [HttpGet]
        public async Task<IActionResult> GetAllConversations()
        {
            var result = await _serviceManager.conversationService.GetAllConversationsAsync();
            return Ok(result);
        }

        // ✅ GET: /api/conversations/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConversationById(int id)
        {
            var result = await _serviceManager.conversationService.GetConversationByIdAsync(id);
            return Ok(result);
        }
    }
}

