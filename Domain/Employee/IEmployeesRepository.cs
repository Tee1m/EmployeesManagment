using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employee
{
    public interface IEmployeesRepository
    {
        System.Threading.Tasks.Task Add(Employee employee);
        System.Threading.Tasks.Task Update(Employee employee);
        System.Threading.Tasks.Task Delete(Employee employee);
        System.Threading.Tasks.Task<IEnumerable<Employee>> GetAll();

    }
}
