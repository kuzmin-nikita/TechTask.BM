using Microsoft.AspNetCore.Mvc;
using TechTask.BM.Application.Exceptions;
using TechTask.BM.Application.Ports;
using Task = TechTask.BM.Application.Models.Task;

namespace TechTask.BM.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
    {
        try
        {
            var task = await _taskService.GetTaskAsync(id, cancellationToken);

            return Ok(task);
        }
        catch (BadRequestException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Guid))]
    public async Task<IActionResult> Post(CancellationToken cancellationToken)
    {
        var guid = await _taskService.AddTaskAsync(cancellationToken);

        return Accepted(guid);
    }
}