using Microsoft.AspNetCore.Mvc;

namespace CloudReadyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static readonly List<string> _tasks = new();

        [HttpGet]
        public IEnumerable<string> Get() => _tasks;

        [HttpPost]
        public IActionResult AddTask([FromBody] string task)
        {
            _tasks.Add(task);
            return Created("", task);
        }

        [HttpDelete]
        public IActionResult ClearTasks()
        {
            _tasks.Clear();
            return NoContent();
        }
    }
}
