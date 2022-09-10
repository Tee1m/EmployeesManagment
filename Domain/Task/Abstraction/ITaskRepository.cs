using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Task.Abstraction
{
    public interface ITasksRepository
    {
        System.Threading.Tasks.Task Add(Task task);
        System.Threading.Tasks.Task Update(Task task);
        Task<IEnumerable<Task>> GetAll();

    }
}
