using Application.Employee.Queries.DTOs;
using AutoMapper;

namespace MVC.Models.MapperProfiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeModel, EmployeeDTO>().ReverseMap();
        }
    }
}
