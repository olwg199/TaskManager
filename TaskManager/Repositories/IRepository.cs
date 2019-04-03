using System;
using System.Collections.Generic;

namespace TaskManager.Repositories
{
    interface IRepository
    {
        void Add(Task task);

        void Update(Task task);

        List<Task> Get();

        List<Task> GetByDate(DateTime date);

        Task GetById(Guid id);

        void AddOrUpdate(Task task);

        void Delete(Task task);
    }
}
