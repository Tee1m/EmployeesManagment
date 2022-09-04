using Domain.Employee;
using Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private EmployeeDbContext _employeeContext;

        public EmployeesRepository(EmployeeDbContext context)
        {
            this._employeeContext = context;
        }

        public async Task Add(Employee employee)
        {
            await _employeeContext.Employees.AddAsync(employee);
        }

        public async Task Update(Employee employee)
        {
            await Task.Run(() =>
            {
                _employeeContext.Employees.Update(employee);
            });
        }
        public async Task Delete(Employee employee)
        {
            await Task.Run(() =>
            {
                _employeeContext.Employees.Remove(employee);
            });
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return _employeeContext.Employees;
        }
    }
}
