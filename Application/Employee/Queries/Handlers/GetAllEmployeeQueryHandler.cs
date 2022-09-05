using Application.Configuration.Data;
using Application.Employee.Queries.DTOs;
using Domain.Employee;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee.Queries.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllEmployeesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlQuery = "SELECT *" +
                                    "FROM [Employees]";

            IDbCommand command = connection.CreateCommand();

            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;
            command.Connection.Open();

            IDataReader reader = command.ExecuteReader();

            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            while (reader.Read())
            {
                var employeeDTO = new EmployeeDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    SecondName = reader.GetString(reader.GetOrdinal("SecondName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Role = (Role) reader.GetInt32(reader.GetOrdinal("Role"))
                };

                employees.Add(employeeDTO);
            }

            connection.Dispose();

            return employees;
        }
    }
}
