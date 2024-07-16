namespace Corruption.API.DTO;

public class MessageRequest
{
    public string SenderId { get; set; }

    public string RecipientId { get; set; }

    public string Content { get; set; }

    public string CreateTime { get; set; }
}