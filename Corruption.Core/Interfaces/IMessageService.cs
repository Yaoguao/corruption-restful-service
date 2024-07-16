using Corruption.Core.Models;

namespace Corruption.Core.Interfaces;

public interface IMessageService
{
    CorruptionMessage ValidCorruptionMessage(Message message);
}