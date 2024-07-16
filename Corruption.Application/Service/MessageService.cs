using Corruption.Core.Interfaces;
using Corruption.Core.Models;
using MyMLApp;

namespace Corruption.Application.Service;

public class MessageService : IMessageService
{

    public CorruptionMessage ValidCorruptionMessage(Message message)
    {
        var sampleData = new SentimentModel.ModelInput()
        {
            Col0 = message.Content
        };

        var result = SentimentModel.Predict(sampleData);

        var resCor = (double) result.Score[0] * 100;
        var resNormalCor = (double)result.Score[1] * 100;

        var conclusion = resCor > 70.0 ? "Cor" : "No cor";

        var corruptionMessage = new CorruptionMessage(
            Guid.NewGuid(),
            message.Content,
            resCor,
            resNormalCor,
            conclusion
        );
        
        //TODO - add in database
        

        return corruptionMessage;
    }
}