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
    
    private readonly ICorruptionMessageService _corruptionMessageService;
    
    public MessageController(IMessageService messageService, ICorruptionMessageService corruptionMessageService)
    {
        _messageService = messageService;
        _corruptionMessageService = corruptionMessageService;
    }

    [HttpPost]
    public ActionResult<CorruptionMessage> Insert([FromBody] MessageRequest messageRequest)
    {
        
        var sampleData = new SentimentModel.ModelInput()
        {
            Col0 = messageRequest.Content
        };

        Guid messageId;

        var result = SentimentModel.Predict(sampleData);

        var resCor = (double) result.Score[0] * 100;
        var resNormalCor = (double)result.Score[1] * 100;

        var conclusion = resCor > 60.0 ? "Corruption" : "No corruption";

        if (resCor > 60.0)
        {
            var (message, error) = Message.Create(
                Guid.NewGuid(),
                messageRequest.SenderId,
                messageRequest.RecipientId,
                messageRequest.Content,
                messageRequest.CreateTime
            );

            _messageService.Insert(message);
            messageId = message.Id;
            
            var (corruptionMessage, errorCor) = CorruptionMessage.Create(
                Guid.NewGuid(),
                messageRequest.Content,
                resCor,
                resNormalCor,
                conclusion,
                messageId
            );

            _corruptionMessageService.Insert(corruptionMessage);

            return Ok(corruptionMessage);
        }

        var noCorruptionMessageResponse = new NoCorruptionMessageResponse(
            messageRequest.Content,
            resCor,
            resNormalCor,
            conclusion
        );

        return Ok(noCorruptionMessageResponse);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Message>> Find(Guid id)
    {
        var message = await _messageService.Find(id);

        return Ok(message);
    }

    [HttpGet]
    public async Task<ActionResult<List<Message>>> FindAll()
    {
        var messages = await _messageService.FindAll();

        return Ok(messages);
    }
}