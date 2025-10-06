using Shared.DataTransferObject.Message;

namespace ServiceAbstraction
{
    public interface IConversations
    {
        Task<ConversationDto> CreateConversationAsync(CreateConversationDto createConversation);
        Task<IEnumerable<ConversationDto>> GetAllConversationsAsync();
        Task<ConversationDto> GetConversationByIdAsync(int id);

    }
}
