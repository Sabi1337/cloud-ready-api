using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<string> Tasks = new();

    [HttpGet]
    public IEnumerable<string> Get() => Tasks;

    [HttpPost]
    public IActionResult Add([FromBody] string task)
    {
        Tasks.Add(task);
        return Ok();
    }
}
