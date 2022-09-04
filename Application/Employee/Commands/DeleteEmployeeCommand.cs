using MediatR;

namespace Application.Employee.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }
    }
}
