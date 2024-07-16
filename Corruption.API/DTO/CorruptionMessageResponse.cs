namespace Corruption.API.DTO;

public record CorruptionMessageResponse(
    string Content, 
    double ResultCorruption, 
    double ResultNormalCorruption,
    string Conclusion,
    Guid MessageId
    );