using Corruption.Core.Models;

namespace Corruption.Core.Interfaces;

public interface ICorruptionMessageService
{
    Task<CorruptionMessage> Find(Guid id);

    Task<List<CorruptionMessage>> FindAll();

    Task<Guid> Insert(CorruptionMessage corruptionMessage);
}