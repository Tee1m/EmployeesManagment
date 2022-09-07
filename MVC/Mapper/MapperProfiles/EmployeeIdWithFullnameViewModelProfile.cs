using Application.Employee.Queries.DTOs;
using AutoMapper;

namespace MVC.Models.MapperProfiles
{
    public class EmployeeIdWithFullnameViewModelProfile : Profile
    {
        public EmployeeIdWithFullnameViewModelProfile()
        {
            CreateMap<EmployeeDTO, EmployeeIdWithFullnameViewModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(value => value.Id))
                .ForMember(dest => dest.FullName, src => src.MapFrom(value => value.FirstName + " " + value.SecondName));
        }
    }
}
