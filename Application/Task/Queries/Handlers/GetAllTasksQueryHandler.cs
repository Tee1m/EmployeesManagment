using Application.Configuration.Data;
using Application.Task.DTOs;
using Domain.Task.State;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Task.Queries.Handlers
{
    internal class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskDTO>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllTasksQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;   
        }

        public async Task<IEnumerable<TaskDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlQuery = "SELECT *" +
                                    "FROM [Tasks]";

            IDbCommand command = connection.CreateCommand();

            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;

            IDataReader reader = command.ExecuteReader();

            List<TaskDTO> tasks = new List<TaskDTO>();

            while (reader.Read())
            {
                var task = new TaskDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    CurrentState = (TaskState) reader.GetInt32(reader.GetOrdinal("CurrentState")),
                    FinishDate = reader.GetDateTime(reader.GetOrdinal("FinishedDate"))
                };

                tasks.Add(task);
            }

            connection.Dispose();

            return tasks;
        }
    }
}
