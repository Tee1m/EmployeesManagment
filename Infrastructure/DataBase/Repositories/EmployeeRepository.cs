using Domain.Employee;
using Domain.Repositories;
using Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext context)
        {
            this._employeeContext = context;
        }

        public async Task Add(Employee employee)
        {
            await _employeeContext.AddAsync(employee);
        }

        public async Task Update(Employee employee)
        {
            await Task.Run(() =>
            {
                _employeeContext.Update(employee);
            });
        }
    }
}
