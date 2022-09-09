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
        [InlineData("Takie Imie", null,  Role.Programer, "wp@p.pl")]
        [InlineData(null, "Takie nazwisko", Role.Qa, "wp@12wp.pl")]
        [InlineData("Takie Imie", "Takie nazwisko", null, "wp@12wp.pl")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.ProjectManager, null)]
        [InlineData(null, null, null, null)]
        public async void Employee_MustHave_AllValues(string firstName, string secondName, Role role, string email)
        {
            //when
            var moqedChecker = new Mock<IEmployeeUniquenessChecker>();
            moqedChecker.Setup(moq => moq.IsUnique(""))
                .ReturnsAsync(true);

            //given
            Func<Task> act = async () => Employee.Create(firstName, secondName, role, email, moqedChecker.Object);

            //then
            await Assert.ThrowsAsync<BusinessRuleException>(act);
        }

        [Theory]
        [InlineData("Takie Imie", "Takie nazwisko", Role.Programer, "wp@.pl")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.Qa, "@12wp.pl")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.ProjectManager, "wp@12wppl")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.ProjectManager, "w.p@12wppl")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.ProjectManager, ".p@12wppl")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.ProjectManager, ".p@12wppl.")]
        [InlineData("Takie Imie", "Takie nazwisko", Role.ProjectManager, "p@12wppl.")]
        public async void Employee_EmailMust_BeValid(string firstName, string secondName, Role role, string email)
        {
            //when
            var moqedChecker = new Mock<IEmployeeUniquenessChecker>();
            moqedChecker.Setup(moq => moq.IsUnique(""))
                .ReturnsAsync(true);

            //given
            Func<Task> act = async () => Employee.Create(firstName, secondName, role, email, moqedChecker.Object);

            //then
            await Assert.ThrowsAsync<BusinessRuleException>(act);
        }

    }
}
