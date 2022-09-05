using Domain.Task;
using Infrastructure.DataBase;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TasksRepoository : ITasksRepository
    {
        private EmployeeDbContext _employeeContext;

        public TasksRepoository(EmployeeDbContext context)
        {
            this._employeeContext = context;
        }

        public async System.Threading.Tasks.Task Add(Domain.Task.Task task)
        {
            await _employeeContext.Tasks.AddAsync(task);
            _employeeContext.SaveChanges();
        }

        public async System.Threading.Tasks.Task Update(Domain.Task.Task task)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                _employeeContext.Tasks.Update(task);
                _employeeContext.SaveChanges();
            });
        }

        public async System.Threading.Tasks.Task<IEnumerable<Domain.Task.Task>> GetAll()
        {
            return _employeeContext.Tasks;
        }
    }
}
