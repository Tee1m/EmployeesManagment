using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employee.Abstraction
{
    public interface IEmployeeUniquenessChecker
    {
        Task<bool> IsUnique(string telephoneNumber);
    }
}
