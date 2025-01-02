using Task = appointmentAPI.Models.Task;

namespace appointmentAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        List<Task> tasks = new List<Task>();
        private int nextId = 1; 
        public void AddTask(Task task)
        {
            task.Id = nextId++;
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

        public void UpdateTask(int id, Task task)
        {
            Task taskToUpdate = tasks.First(t => t.Id == id);
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
