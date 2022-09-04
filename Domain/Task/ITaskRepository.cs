using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Task;

namespace Domain.Task
{
    public interface ITasksRepository
    {
        System.Threading.Tasks.Task Add(Domain.Task.Task task);
        System.Threading.Tasks.Task Update(Domain.Task.Task task);
        System.Threading.Tasks.Task<IEnumerable<Domain.Task.Task>> GetAll();

    }
}
