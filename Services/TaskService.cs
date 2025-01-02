using Task = appointmentAPI.Models.Task;
using appointmentAPI.Repository;

namespace appointmentAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void AddTask(Task task)
        {
            try
            {
                var existingTask = _taskRepository.GetTaskDetail(task.Id);
                if (existingTask != null)
                {
                    throw new Exception("Task already exists");
                }
                _taskRepository.AddTask(task);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteTask(int id)
        {
            try
            {
                var existingTask = _taskRepository.GetTaskDetail(id);
                if (existingTask == null)
                {
                    throw new Exception("Task not found");
                }
                _taskRepository.DeleteTask(id);
            }
            catch
            {
                throw;
            }
        }

        public Task GetTaskDetail(int id)
        {
            try
            {
                return _taskRepository.GetTaskDetail(id);
            }
            catch
            {
                throw;
            }
        }

        public List<Task> GetTasks()
        {
            try
            {
                return _taskRepository.GetTasks();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateTask(int id, Task task)
        {
            try
            {
                var existingTask = _taskRepository.GetTaskDetail(id);
                if (existingTask == null)
                {
                    throw new Exception("Task not found");
                }
                _taskRepository.UpdateTask(id, task);
            }
            catch
            {
                throw;
            }
        }
    }
}
