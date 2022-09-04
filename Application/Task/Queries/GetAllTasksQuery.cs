using Application.Task.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.Task.Queries
{
    public class GetAllTasksQuery : IRequest<IEnumerable<TaskDTO>>
    {

    }
}
