using Corruption.API.DTO;
using Corruption.Core.Interfaces;
using Corruption.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corruption.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public ActionResult<CorruptionMessage> validMessageCor([FromBody] MessageRequest messageRequest)
    {
        var (message, error) = Message.Create(
            Guid.NewGuid(),
            messageRequest.SenderId,
            messageRequest.RecipientId,
            messageRequest.Content,
            messageRequest.CreateTime
        );

        return Ok(_messageService.ValidCorruptionMessage(message));
    }
}