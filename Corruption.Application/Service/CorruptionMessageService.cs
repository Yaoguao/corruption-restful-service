using Corruption.Core.Interfaces;
using Corruption.Core.Models;

namespace Corruption.Application.Service;

public class CorruptionMessageService : ICorruptionMessageService
{
    private readonly ICorruptionMessageRepository _corruptionMessageRepository;

    public CorruptionMessageService(ICorruptionMessageRepository corruptionMessageRepository)
    {
        _corruptionMessageRepository = corruptionMessageRepository;
    }

    public async Task<CorruptionMessage> Find(Guid id)
    {
        return await _corruptionMessageRepository.Find(id);
    }

    public async Task<List<CorruptionMessage>> FindAll()
    {
        return await _corruptionMessageRepository.FindAll();
    }
    
    public async Task<Guid> Insert(CorruptionMessage corruptionMessage)
    {
        return await _corruptionMessageRepository.Insert(corruptionMessage);
    }
}