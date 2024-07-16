using Corruption.Core.Interfaces;
using Corruption.Core.Models;

namespace Corruption.Application.Service;

public class MessageService : IMessageService
{

    public CorruptionMessage ValidCorruptionMessage(Message message)
    {
        /*var (message, error) = Message.Create(
            Guid.NewGuid(),
            messageRequest.SenderId,
            messageRequest.RecipientId,
            messageRequest.Content,
            messageRequest.CreateTime
        );

        return Ok(_messageService.ValidCorruptionMessage(message));*/
        return null;
    }
}