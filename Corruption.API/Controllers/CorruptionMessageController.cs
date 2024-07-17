using Corruption.Core.Interfaces;
using Corruption.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corruption.API.Controllers;


[ApiController]
[Route("[controller]")]
public class CorruptionMessageController : ControllerBase
{
    private readonly ICorruptionMessageService _corruptionMessageService;

    public CorruptionMessageController(ICorruptionMessageService corruptionMessageService)
    {
        _corruptionMessageService = corruptionMessageService;
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CorruptionMessage>> Find(Guid id)
    {
        var corMessage = await _corruptionMessageService.Find(id);

        return Ok(corMessage);
    }

    [HttpGet]
    public async Task<ActionResult<List<CorruptionMessage>>> FindAll()
    {
        var corMessages = await _corruptionMessageService.FindAll();

        return Ok(corMessages);
    }
    
}