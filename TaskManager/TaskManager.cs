using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TaskManager.entity;

namespace TaskManager
{
    public class TaskManager
    {
        private List<Task> _tasks;

        public TaskManager()
        {
            //todo: TaskRepository should not be static and should be injected into constructor of TaskManager 
            _tasks = TaskRepository.Get();
        }

        public List<Task> Get()
        {
            return _tasks;
        }

        public List<Task> GetByDate(DateTime date)
        {
            return _tasks.FindAll(t => t.Date == date);
        }

        public Task GetById(string id)
        {
            return _tasks.Find(t => t.Id == Guid.Parse(id));
        }
//todo: 'Task' is excess
        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }
//todo: 'Task' is excess
        public void EditTask(Task task)
        {
            Task currentTask = _tasks.Find(t => t.Id == task.Id);
            int currentTaskIndex = _tasks.IndexOf(currentTask);

            _tasks[currentTaskIndex] = task;
        }   
        
        //todo: 'Tasks' is excess
        public void SaveTasks()
        {
            TaskRepository.Save(_tasks);
        }
    }
}
