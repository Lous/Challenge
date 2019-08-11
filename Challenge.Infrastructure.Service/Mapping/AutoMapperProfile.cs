using AutoMapper;
using AutoMapper.Configuration;
using Challenge.Domain.Entities;
using Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Service.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /// UserViewModel To User
            CreateMap<UserViewModel, User>()
                .ForMember(destination => destination.Firstname, options => options.MapFrom(source => source.Firstname))
                .ForMember(destination => destination.Lastname, options => options.MapFrom(source => source.Lastname))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.Password, options => options.MapFrom(source => source.Password))
                .ForMember(destination => destination.Phones, options => options.Ignore());

            /// User To UserViewModel
            CreateMap<User, UserViewModel>()
                .ForMember(destination => destination.Firstname, options => options.MapFrom(source => source.Firstname))
                .ForMember(destination => destination.Lastname, options => options.MapFrom(source => source.Lastname))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.Password, options => options.MapFrom(source => source.Password))
                .ForMember(destination => destination.Phones, options => options.Ignore());
        }
    }
}
