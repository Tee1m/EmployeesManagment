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
        readonly string _firstName = "Maciej";
        readonly string _secondName = "Maciejowaty";
        readonly Role _role = Role.Programer;
        readonly string _email = "wp@pw.pl";


        [Fact]
        public void Employee_WhoObeysAllRules_WillBeCreated()
        {
            //when
            var moqedRepo = new Mock<IEmployeesRepository>();
            moqedRepo.Setup(moq => moq.GetAll())
                .ReturnsAsync(new List<Employee>());

            //given
            var checker = new EmployeeUniquenessChecker(moqedRepo.Object);

            var result = Employee.Create(_firstName, _secondName, _role, _email, checker);

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
                Employee.Create(_firstName, _secondName, _role, _email, moqedChecker.Object)
            });

            //given
            var checker = new EmployeeUniquenessChecker(moqedRepo.Object);

            Func<Task> act = async () => Employee.Create(_firstName, _secondName, _role, _email, checker);

            //then
            await Assert.ThrowsAsync<BusinessRuleException>(act);
        }

        [Theory]
        [InlineData("Takie Imie", null,  Role.Programer, "wp@wp.pl")]
        [InlineData(null, "Takie nazwisko", Role.Qa, "wp@12wp.pl")]
        [InlineData("Takie Imie", "Takie nazwisko", null, "wp@12wp.pl")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.ProjectManager, null)]
        public async void Employee_MustHave_AllValues(string firstName, string secondName, Role role, string email)
        {
            //when
            var moqedChecker = new Mock<IEmployeeUniquenessChecker>();
            moqedChecker.Setup(moq => moq.IsUnique(""))
                .ReturnsAsync(true);

            //given
            Func<Task> act = async () => Employee.Create(_firstName, null, _role, _email, moqedChecker.Object);

            //then
            await Assert.ThrowsAsync<BusinessRuleException>(act);
        }

    }
}
