using Task = appointmentAPI.Models.Task;
namespace appointmentAPI.Services
{
    public interface ITaskService
    {
        void AddTask(Task task);
        List<Task> GetTasks();
        Task GetTaskDetail(int id);
        void UpdateTask(int id, Task task);
        void DeleteTask(int id);
    }
}
