using Application.Employee.Commands;
using Application.Employee.Queries;
using Application.Employee.Queries.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateEmployeeCommand employee)
        {
            var result = await _mediator.Send(employee);

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var emloyees = await _mediator.Send(new GetAllEmployeesQuery()) as List<EmployeeDTO>;
            var employeesModel = _mapper.Map<List<EmployeeViewModel>>(emloyees);

            return View(employeesModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIdsWithFullName()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery()) as List<EmployeeDTO>;
            var employeesIdWithFullNameModal = _mapper.Map<List<EmployeeIdWithFullnameViewModel>>(employees);

            string jsonResponse = JsonSerializer.Serialize(employeesIdWithFullNameModal);

            return Json(jsonResponse);
        }
    }
}
