using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObject.Message;

namespace Presentation.Controllers
{
    public class MessageController(IServiceManger _serviceManger):BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateMessage( CreateMessageDto dto)
        {
            var result = await _serviceManger.MessageService.CreateMessageAsync(dto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetAllMessages()
        {
            var result = await _serviceManger.MessageService.GetAllMessagesAsync();
            return Ok(result);
        }

        [HttpGet("by-conversation/{conversationId}")]
        public async Task<ActionResult> GetMessagesByConversationId(int conversationId)
        {
            var result = await _serviceManger.MessageService.GetMessagesByConversationIdAsync(conversationId);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMessageById(int id)
        {
            var result = await _serviceManger.MessageService.GetMessageByIdAsync(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            var result = await _serviceManger.MessageService.DeleteMessageAsync(id);
            return Ok(new { success = result, message = "Message deleted successfully" });
        }





    }
}
