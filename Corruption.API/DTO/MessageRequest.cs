namespace Corruption.API.DTO;

public record MessageRequest(
    string SenderId, 
    string RecipientId, 
    string Content, 
    string CreateTime
    );