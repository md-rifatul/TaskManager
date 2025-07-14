using Microsoft.AspNetCore.Mvc;
using TaskManager.Model;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : Controller
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        [HttpGet]
        public IActionResult GetTask()
        {
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(TaskItem task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            return Ok(task);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = tasks.FirstOrDefault(x=>x.Id == id);
            if (task == null)
            {
                return BadRequest();
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(x=>x.Id ==id);
            if (task == null)
            {
                return BadRequest();
            }
            tasks.Remove(task);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem updateTask)
        {
            var task = tasks.FirstOrDefault(x=>x.Id == id);
            if(task == null)
            {
                return BadRequest();
            }
            task.Name = updateTask.Name;
            task.IsComplete = updateTask.IsComplete;
            return Ok(task);
        }
    }
}
