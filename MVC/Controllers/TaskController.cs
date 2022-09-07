using Application.Configuration.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVC.Controllers.Requests;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TaskController(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTaskRequest request)
        {
            var command = _mapper.Map<CreateTaskCommand>(request);

            var result = await _mediator.Send(command);

            var jsonResponse = JsonSerializer.Serialize(result);

            return Json(jsonResponse);
        }
    }
}
