namespace Corruption.Core.Models;

public class Message
{
    public Guid Id { get; set; }

    public string SenderId { get; }

    public string RecipientId { get; }

    public string Content { get; }

    public string CreateTime { get; }


    private Message(Guid id, string senderId, string recipientId, string content, string createTime)
    {
        Id = id;
        SenderId = senderId;
        RecipientId = recipientId;
        Content = content;
        CreateTime = createTime;
    }

    public static (Message message, string error) Create(Guid id, string senderId, string recipientId, string content,
        string createTime)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(content))
        {
            error = "Content is null";
        }

        var message = new Message(id, senderId, recipientId, content, createTime);

        return (message, error);
    }
}