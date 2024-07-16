using Corruption.Core.Interfaces;
using Corruption.Core.Models;

namespace Corruption.Application.Service;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<List<Message>> FindAll()
    {
        return await _messageRepository.FindAll();
    }

    public async Task<Message> Find(Guid id)
    {
        return await _messageRepository.Find(id);
    }

    public async Task<Guid> Insert(Message message)
    {
        return await _messageRepository.Insert(message);
    }
}