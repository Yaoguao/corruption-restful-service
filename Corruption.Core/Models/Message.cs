using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Corruption.Core.Models;

public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public string SenderId { get; set; }

    public string RecipientId { get; set; }

    public string Content { get; set; }

    public string CreateTime { get; set; }


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