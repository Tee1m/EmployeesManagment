using Application.Configuration.Commands;
using Application.Employee.Queries.DTOs;
using AutoMapper;
using MVC.Controllers.Requests;
using System;

namespace MVC.Models.MapperProfiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeDTO, EmployeeViewModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(value => value.Id))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(value => value.FirstName))
                .ForMember(dest => dest.SecondName, src => src.MapFrom(value => value.SecondName))
                .ForMember(dest => dest.Email, src => src.MapFrom(value => value.Email))
                .ForMember(dest => dest.EnumRole, src => src.MapFrom(value => value.Role));

            CreateMap<EmployeeDTO, EmployeeIdWithFullnameViewModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(value => value.Id))
                .ForMember(dest => dest.FullName, src => src.MapFrom(value => value.FirstName + " " + value.SecondName));

            CreateMap<CreateTaskRequest, CreateTaskCommand>()
                .ForMember(dest => dest.Title, src => src.MapFrom(value => value.Title))
                .ForMember(dest => dest.Description, src => src.MapFrom(value => value.Description))
                .ForMember(dest => dest.FinallDate, src => src.MapFrom(value => DateTime.Parse(value.FinallDate)))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(value => value.EmployeeId))
                .ForMember(dest => dest.State, src => src.MapFrom(value => value.State));
        }
    }
}
