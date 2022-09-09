using System;
using Xunit;
using Moq;
using Domain.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DomainServices;
using Domain.Employee.Rules;
using Domain;

namespace UnitTests.Domain
{
    public class EmployeeTests
    {
        readonly string firstName = "Maciej";
        readonly string secondName = "Maciejowaty";
        readonly Role role = Role.Programer;
        readonly string email = "wp@pw.pl";


        [Fact]
        public void Employee_WithUniquenessEmail_WillBeCreated()
        {
            //when
            var moqedRepo = new Mock<IEmployeesRepository>();
            moqedRepo.Setup(moq => moq.GetAll())
                .ReturnsAsync(new List<Employee>());

            //given
            var checker = new EmployeeUniquenessChecker(moqedRepo.Object);

            var result = Employee.Create(firstName, secondName, role, email, checker);

            //then
            Assert.NotNull(result);
        }

        [Fact]
        public async void Employee_WhithoutUniquenessEmaill_WillNotCreated()
        {
            //when
            var moqedChecker = new Mock<IEmployeeUniquenessChecker>();
            moqedChecker.Setup(moq => moq.IsUnique(""))
                .ReturnsAsync(true);

            var moqedRepo = new Mock<IEmployeesRepository>();
            moqedRepo.Setup(moq => moq.GetAll())
            .ReturnsAsync(new List<Employee>() { 
                Employee.Create(firstName, secondName, role, email, moqedChecker.Object)
            });

            //given
            var checker = new EmployeeUniquenessChecker(moqedRepo.Object);

            Func<Task> act = async () => Employee.Create(firstName, secondName, role, email, checker);

            //then
            await Assert.ThrowsAsync<BusinessRuleException>(act);
        }
    }
}
