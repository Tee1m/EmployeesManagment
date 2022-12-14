using Application.Configuration.Data;
using Domain.Employee;
using Domain.Employee.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainServices
{
    public class EmployeeUniquenessChecker : IEmployeeUniquenessChecker
    {
        IEmployeesRepository _employeesRepository;

        public EmployeeUniquenessChecker(IEmployeesRepository employeesRepository)
        {
            this._employeesRepository = employeesRepository;
        }

        public async Task<bool> IsUnique(string email)
        {
            var employess = await _employeesRepository.GetAll();

            return employess.Where(x => x.Email == email).Any();
        }
    }
}
