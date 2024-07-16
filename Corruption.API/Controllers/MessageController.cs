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
            
            var corruptionMessageResponse = new CorruptionMessageResponse(
                messageRequest.Content,
                resCor,
                resNormalCor,
                conclusion,
                messageId
            );

            return Ok(corruptionMessageResponse);
        }

        var noCorruptionMessageResponse = new NoCorruptionMessageResponse(
            messageRequest.Content,
            resCor,
            resNormalCor,
            conclusion
        );

        return Ok(noCorruptionMessageResponse);
    }
}