using System.Runtime.InteropServices.JavaScript;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Corruption.Core.Models;

public class CorruptionMessage
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public string Content { get; set; }

    public double ResultCorruption { get; set; }

    public double ResultNormalCorruption { get; set; }

    public string Conclusion { get; set; }
    
    public Guid MessageId { get; set; }

    private CorruptionMessage(Guid id, string content, double resultCorruption, double resultNormalCorruption,
        string conclusion, Guid messageId)
    {
        Id = id;
        Content = content ?? throw new ArgumentNullException(nameof(content));
        ResultCorruption = resultCorruption;
        ResultNormalCorruption = resultNormalCorruption;
        Conclusion = conclusion ?? throw new ArgumentNullException(nameof(conclusion));
        MessageId = messageId;
    }

    public static (CorruptionMessage corruptionMessage, string error) Create(Guid id, string content,
        double resultCorruption, double resultNormalCorruption,
        string conclusion, Guid messageId)
    {
        var error = string.Empty;
        
        if (double.IsNegative(resultCorruption) || double.IsNegative(resultNormalCorruption))
        {
            error = "The result is negative";
        }

        var corruptionMessage 
            = new CorruptionMessage( id, content, resultCorruption, resultNormalCorruption, conclusion, messageId);

        return (corruptionMessage, error);
    }
}