using Task = appointmentAPI.Models.Task;

namespace appointmentAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        List<Task> tasks = new List<Task>();
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void DeleteTask(int id)
        {
            Task taskToDelete = tasks.First(t => t.Id == id);
            if (taskToDelete != null)
            {
                tasks.Remove(taskToDelete);
            }
        }

        public Task GetTaskDetail(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public List<Task> GetTasks()
        {
            return tasks;
        }

        public void UpdateTask(Task task)
        {
            Task taskToUpdate = tasks.First(t => t.Id == task.Id);
            if (taskToUpdate != null)
            {
                taskToUpdate.Name = task.Name;
                taskToUpdate.ScheduledTime = task.ScheduledTime;
                taskToUpdate.ScheduledLocation = task.ScheduledLocation;
                taskToUpdate.Members = task.Members;
            }
        }
    }
}
