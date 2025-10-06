using Shared.DataTransferObject.Message;

namespace ServiceAbstraction
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetAllMessagesAsync();
        Task<MessageDto> CreateMessageAsync(CreateMessageDto dto);
        Task<IEnumerable<MessageDto>> GetMessagesByConversationIdAsync(int conversationId);
        Task<MessageDto> GetMessageByIdAsync(int id);
        Task<bool> DeleteMessageAsync(int id);

    }
}
