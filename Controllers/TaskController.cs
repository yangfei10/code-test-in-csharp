using Task = appointmentAPI.Models.Task;
using appointmentAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        /// <summary>
        /// Returns all tasks
        /// </summary>
        public ActionResult<List<Task>> GetAllTasks()
        {
            try
            {
                var tasks = _taskService.GetTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        /// <summary>
        /// Returns a task by id
        /// </summary>
        public ActionResult<Task> GetTaskById(int id)
        {
            try
            {
                var task = _taskService.GetTaskDetail(id);
                if (task == null)
                {
                    return NotFound($"Task with id {id} not found");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpPost]
        /// <summary>
        /// Create a new task
        /// </summary>
        public ActionResult<string> CreateTask([FromBody] Task task)
        {
            try
            {
                _taskService.AddTask(task);
                return StatusCode(StatusCodes.Status201Created, "Task created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }


        [HttpPut]
        [Route("{id}")]
        /// <summary>
        /// Modify a task
        /// </summary>
        public ActionResult<string> UpdateTask(int id, [FromBody] Task task)
        {
            try
            {
                _taskService.UpdateTask(id, task);
                return StatusCode(StatusCodes.Status200OK, "Task updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        /// <summary>
        /// Delete a task
        /// </summary>
        public ActionResult<string> DeleteTask(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return StatusCode(StatusCodes.Status200OK, "Task deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }
    }
}
