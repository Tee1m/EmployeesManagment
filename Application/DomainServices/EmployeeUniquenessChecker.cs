using Application.Configuration.Data;
using Domain.Employee;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainServices
{
    internal class EmployeeUniquenessChecker : IEmployeeUniquenessChecker
    {
        ISqlConnectionFactory _sqlConnectionFactory;

        public EmployeeUniquenessChecker(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public bool IsUnique(string telephoneNumber)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlQuery = "SELECT TOP 1" +
                                    "FROM [Employees]" +
                                    "WHERE [Employees].[TelephoneNumber] = @TelephoneNumber";

            IDbCommand command = connection.CreateCommand();

            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;

            IDbDataParameter param = command.CreateParameter();
            param.ParameterName = "@TelephoneNumber";
            param.Value = telephoneNumber;

            command.Parameters.Add(param);
            int? result = command.ExecuteNonQuery();

            return !result.HasValue;
        }
    }
}
