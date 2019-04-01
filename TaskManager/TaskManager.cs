using System;
using System.Collections.Generic;
using TaskManager.Repositories;

namespace TaskManager
{
    class TaskManager
    {
        private IRepository _repository;
        private List<Task> _tasks;

        public TaskManager(IRepository repository)
        {
            _repository = repository;
            _tasks = _repository.Get();
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

        public void Add(Task task)
        {
            _tasks.Add(task);
        }

        public void Edit(Task task)
        {
            Task currentTask = _tasks.Find(t => t.Id == task.Id);
            int currentTaskIndex = _tasks.IndexOf(currentTask);

            _tasks[currentTaskIndex] = task;
        }   
        
        public void Save()
        {
            _repository.Save(_tasks);
        }

        internal void Delete(Task task)
        {
            _repository.Delete(task);

            _tasks.Remove(task);
        }
    }
}
