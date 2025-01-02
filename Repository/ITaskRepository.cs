﻿using Task = appointmentAPI.Models.Task;
namespace appointmentAPI.Repository
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        List<Task> GetTasks();
        Task GetTaskDetail(int id);
        void UpdateTask(Task task);
        void DeleteTask(int id);

    }
}