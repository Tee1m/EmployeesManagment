using Application.Configuration.Data;
using Application.Configuration.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configuration.Queries
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeDTO>>
    {
    }

    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllEmployeeQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlQuery = "SELECT *" +
                                    "FROM [Employees]";

            IDbCommand command = connection.CreateCommand();

            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;

            IDataReader reader = command.ExecuteReader();

            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            while (reader.Read())
            {
                var employeeDTO = new EmployeeDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    SecondName = reader.GetString(reader.GetOrdinal("SecondName")),
                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                    TelephoneNumber = reader.GetString(reader.GetOrdinal("TelephoneNumber"))
                };

                employees.Add(employeeDTO);
            }

            connection.Dispose();

            return employees;
        }
    }
}
