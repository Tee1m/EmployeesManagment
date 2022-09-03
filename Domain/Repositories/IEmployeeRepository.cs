using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        System.Threading.Tasks.Task Add(Employee.Employee employee);
        System.Threading.Tasks.Task Update(Employee.Employee employee);

    }
}
