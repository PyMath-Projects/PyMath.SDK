using System.Transactions;
using MassTransit;
using MassTransit.Eventing;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public HomeController(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Index(CancellationToken cancellationToken = default)
    {
        using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                   new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
        {
            _eventBus.Publish(new HelloEvent());
            transaction.Complete();
        }
        await _eventBus.FlushAllAsync(cancellationToken);
        return Created(string.Empty, null);
    }
}