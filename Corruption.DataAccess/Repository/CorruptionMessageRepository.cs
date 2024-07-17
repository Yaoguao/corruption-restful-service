using Corruption.Core.Interfaces;
using Corruption.Core.Models;
using MongoDB.Driver;

namespace Corruption.DataAccess.Repository;

public class CorruptionMessageRepository : ICorruptionMessageRepository
{
    
    private readonly CorruptionContext _context;

    public CorruptionMessageRepository(CorruptionContext corruptionContext)
    {
        _context = corruptionContext;
    }
    
    public async Task<CorruptionMessage> Find(Guid id)
    {
        return await _context.CorruptionMessages.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<CorruptionMessage>> FindAll()
    {
        var corruptionMessages = await _context.CorruptionMessages.Find(_ => true).ToListAsync();
        return corruptionMessages;
    }

    public async Task<Guid> Insert(CorruptionMessage corruptionMessage)
    {
        await _context.CorruptionMessages.InsertOneAsync(corruptionMessage);
        return corruptionMessage.Id;
    }
}