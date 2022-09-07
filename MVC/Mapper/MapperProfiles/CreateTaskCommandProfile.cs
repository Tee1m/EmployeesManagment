using Application.Configuration.Commands;
using AutoMapper;
using MVC.Controllers.Requests;
using System;

namespace MVC.Models.MapperProfiles
{
    public class CreateTaskCommandProfile : Profile
    {
        public CreateTaskCommandProfile()
        {
            CreateMap<CreateTaskRequest, CreateTaskCommand>()
                .ForMember(dest => dest.Title, src => src.MapFrom(value => value.Title))
                .ForMember(dest => dest.Description, src => src.MapFrom(value => value.Description))
                .ForMember(dest => dest.FinallDate, src => src.MapFrom(value => DateTime.Parse(value.FinallDate)))
                .ForMember(dest => dest.EmployeeId, src => src.MapFrom(value => value.EmployeeId))
                .ForMember(dest => dest.State, src => src.MapFrom(value => value.State));
        }
    }
}
