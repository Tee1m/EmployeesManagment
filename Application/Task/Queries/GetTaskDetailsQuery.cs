using Application.Task.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.Task.Queries
{
    public class GetTaskDetailsQuery : IRequest<IEnumerable<TaskDetailsDTO>>
    {
        public int Id { get; set; }
    }
}
