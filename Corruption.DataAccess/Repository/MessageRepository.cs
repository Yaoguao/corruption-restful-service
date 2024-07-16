using Corruption.Core.Interfaces;
using Corruption.Core.Models;
using MongoDB.Driver;


namespace Corruption.DataAccess.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly CorruptionContext _context;

    public MessageRepository(CorruptionContext corruptionContext)
    {
        _context = corruptionContext;
    }

    public async Task<List<Message>> FindAll()
    {
        return await _context.Messages.Find(_ => true).ToListAsync();
    }
    

    public async Task<Message> Find(Guid id)
    {
        return await _context.Messages.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Guid> Insert(Message message)
    {
        await _context.Messages.InsertOneAsync(message);
        return message.Id;
    }

}