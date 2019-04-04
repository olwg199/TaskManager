using System;
using System.Collections.Generic;
using TaskManager.Model;

namespace TaskManager.Repositories
{
    interface ITaskRepository
    {
        void AddOrUpdate(Task task);
        
        List<Task> GetByDate(DateTime date);

        Task GetById(Guid id);

        void Delete(Task task);
    }
}
