using System.Runtime.InteropServices.JavaScript;

namespace Corruption.Core.Models;

public class CorruptionMessage
{
    public Guid Id { get; set; }

    public string Content { get; }

    public double ResultCorruption { get; }

    public double ResultNormalCorruption { get; }

    public string Conclusion { get; }

    public CorruptionMessage(Guid id, string content, double resultCorruption, double resultNormalCorruption,
        string conclusion)
    {
        Id = id;
        Content = content ?? throw new ArgumentNullException(nameof(content));
        ResultCorruption = resultCorruption;
        ResultNormalCorruption = resultNormalCorruption;
        Conclusion = conclusion ?? throw new ArgumentNullException(nameof(conclusion));
    }

    /*public static (CorruptionMessage corruptionMessage, string error) Create(Guid id, string content,
        double resultCorruption, double resultNormalCorruption,
        string conclusion)
    {
        var error = string.Empty;
        
        if (double.IsNegative(resultCorruption) || double.IsNegative(resultNormalCorruption))
        {
            error = "The result is negative";
        }

        var corruptionMessage = new CorruptionMessage( id, content, resultCorruption, resultNormalCorruption, conclusion);

        return (corruptionMessage, error);
    }*/
}