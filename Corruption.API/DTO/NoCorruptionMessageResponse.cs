namespace Corruption.API.DTO;

public record NoCorruptionMessageResponse(
    string Content, 
    double ResultCorruption, 
    double ResultNormalCorruption, 
    string Conclusion
    );
