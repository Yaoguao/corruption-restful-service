using Corruption.Core.Models;

namespace Corruption.Core.Interfaces;

public interface IMessageRepository
{
    Task<List<Message>> FindAll();

    Task<Message> Find(Guid id);

    Task<Guid> Insert(Message message);
}