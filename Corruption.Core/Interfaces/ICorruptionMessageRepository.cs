using Corruption.Core.Models;

namespace Corruption.Core.Interfaces;

public interface ICorruptionMessageRepository
{
    Task<CorruptionMessage> Find(Guid id);

    Task<Guid> Insert(CorruptionMessage corruptionMessage);
}