using Domain.Entities;
using Domain.Interfaces;
using MapsterMapper;
using ServiceAbstraction;
using Shared.DataTransferObject.Message;

namespace Services.Messagess
{
   public class MessageService(IUnitOfWork _unitOfWork, IMapper _mapper) :IMessageService
    {

        
            public async Task<MessageDto> CreateMessageAsync(CreateMessageDto createMessageDto)
            {
                var messageRepo = _unitOfWork.GetRepository<Message, int>();
                var conversationRepo = _unitOfWork.GetRepository<Conversation, int>();
                var userRepo = _unitOfWork.GetRepository<User, int>();

                // ✅ Check if conversation exists
                var conversation = await conversationRepo.GetByIdAsync(createMessageDto.ConversationId);
                if (conversation == null)
                    throw new Exception($"Conversation with ID {createMessageDto.ConversationId} not found");

                // ✅ Check if sender exists
                var sender = await userRepo.GetByIdAsync(createMessageDto.SenderId);
                if (sender == null)
                    throw new Exception($"Sender with ID {createMessageDto.SenderId} not found");

                // ✅ Create new message
                var message = new Message
                {
                    Content = createMessageDto.Content,
                    SentAt = DateTime.UtcNow,
                    IsRead = false,
                    SenderId = createMessageDto.SenderId,
                    ConversationId = createMessageDto.ConversationId
                };

                await messageRepo.AddAsync(message);
                await _unitOfWork.SaveChangesAsync();

                return _mapper.Map<MessageDto>(message);
            }

            public async Task<IEnumerable<MessageDto>> GetAllMessagesAsync()
            {
                var messageRepo = _unitOfWork.GetRepository<Message, int>();
                var messages = await messageRepo.GetAllAsync();
                return _mapper.Map<IEnumerable<MessageDto>>(messages);
            }

            public async Task<IEnumerable<MessageDto>> GetMessagesByConversationIdAsync(int conversationId)
            {
                var messageRepo = _unitOfWork.GetRepository<Message, int>();
                var allMessages = await messageRepo.GetAllAsync();
                var conversationMessages = allMessages.Where(m => m.ConversationId == conversationId);

                if (!conversationMessages.Any())
                    throw new Exception($"No messages found for conversation ID {conversationId}");

                return _mapper.Map<IEnumerable<MessageDto>>(conversationMessages);
            }

            public async Task<MessageDto> GetMessageByIdAsync(int id)
            {
                var messageRepo = _unitOfWork.GetRepository<Message, int>();
                var message = await messageRepo.GetByIdAsync(id);
                if (message == null)
                    throw new Exception($"Message with ID {id} not found");

                return _mapper.Map<MessageDto>(message);
            }

            public async Task<bool> DeleteMessageAsync(int id)
            {
                var messageRepo = _unitOfWork.GetRepository<Message, int>();
                var message = await messageRepo.GetByIdAsync(id);

                if (message == null)
                    throw new Exception($"Message with ID {id} not found");

                 messageRepo.RemoveAsync(message);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
        }
    }



