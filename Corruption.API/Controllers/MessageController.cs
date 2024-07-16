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
    public ActionResult<CorruptionMessage> validMessageCor([FromBody] MessageRequest messageRequest)
    {
        
        var sampleData = new SentimentModel.ModelInput()
        {
            Col0 = messageRequest.Content
        };

        var result = SentimentModel.Predict(sampleData);

        var resCor = (double) result.Score[0] * 100;
        var resNormalCor = (double)result.Score[1] * 100;

        var conclusion = resCor > 70.0 ? "Cor" : "No cor";

        var corruptionMessage = new CorruptionMessage(
            Guid.NewGuid(),
            messageRequest.Content,
            resCor,
            resNormalCor,
            conclusion
        );

        return Ok(corruptionMessage);
    }
}