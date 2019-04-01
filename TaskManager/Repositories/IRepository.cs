using System.Collections.Generic;

namespace TaskManager.Repositories
{
    interface IRepository
    {
        List<Task> Get();

        void Save(List<Task> tasks);

        void Delete(Task task);
    }
}
