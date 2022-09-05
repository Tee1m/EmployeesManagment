using Application.Employee.Queries.DTOs;
using AutoMapper;

namespace MVC.Models.MapperProfiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeDTO, EmployeeModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(value => value.Id))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(value => value.FirstName))
                .ForMember(dest => dest.SecondName, src => src.MapFrom(value => value.SecondName))
                .ForMember(dest => dest.Email, src => src.MapFrom(value => value.Email))
                .ForMember(dest => dest.EnumRole, src => src.MapFrom(value => value.Role));
        }
    }
}
