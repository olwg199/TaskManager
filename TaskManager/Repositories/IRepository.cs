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

        void Edit(Task task);

        void Save(List<Task> tasks);

        void Delete(Task task);
    }
}
