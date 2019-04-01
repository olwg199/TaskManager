using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Repositories
{
    interface IRepository
    {
        List<Task> Get();

        void Save(List<Task> tasks);

        void Delete(Task task);
    }
}
