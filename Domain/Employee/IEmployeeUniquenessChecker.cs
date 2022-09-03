using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employee
{
    public interface IEmployeeUniquenessChecker
    {
        bool IsUnique(string telephoneNumber);
    }
}
