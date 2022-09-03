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

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public Task<IActionResult> GetAll()
        {

            return View();
        }
    }
}
