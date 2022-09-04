using Application.Employee.Commands;
using Application.Employee.Queries;
using Application.Employee.Queries.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeeController(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emloyees = await _mediator.Send(new GetAllEmployeesQuery()) as List<EmployeeDTO>;
            var employeesModel = _mapper.Map<List<EmployeeModel>>(emloyees);

            return View(employeesModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateEmployeeCommand employee)
        {
            var result = await _mediator.Send(employee);

            if(result)
                return Ok();

            return BadRequest(result);
        }
    }
}
