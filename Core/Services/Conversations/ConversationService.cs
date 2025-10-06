using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using ServiceAbstraction;
using Shared.DataTransferObject.Message;

namespace Services.Conversations
{
    public class ConversationService(IUnitOfWork _unitOfWork, IMapper _mapper) : IConversations
    {
        public async Task<ConversationDto> CreateConversationAsync(CreateConversationDto createConversation)
        {
            var participants = new List<User>();
            var repo = _unitOfWork.GetRepository<Conversation, int>();
            var userRepo = _unitOfWork.GetRepository<User, int>(); 

            foreach (var userId in createConversation.ParticipantIds)
            {
                var user = await userRepo.GetByIdAsync(userId); 
                if (user == null)
                    throw new Exception($"User with id {userId} not found");
                participants.Add(user);
            }

            var conversation = new Conversation()
            {
                CreatedAt = DateTime.UtcNow,
                Participants = participants
            };

            await repo.AddAsync(conversation);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ConversationDto>(conversation); // ✅ ConversationDto  CreateConversationDto
        }

        public async Task<IEnumerable<ConversationDto>> GetAllConversationsAsync()
        {
            var repo = _unitOfWork.GetRepository<Conversation, int>();
            var conversations = await repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ConversationDto>>(conversations);
        }

        public async Task<ConversationDto> GetConversationByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Conversation, int>();
            var conversation = await repo.GetByIdAsync(id);
            if (conversation == null)
                throw new Exception("Conversation not found");

            return _mapper.Map<ConversationDto>(conversation);
        }
    }
}
