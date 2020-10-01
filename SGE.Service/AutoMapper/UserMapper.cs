using AutoMapper;
using SGE.DataAccess.Dtos;
using SGE.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Service.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Cpf, options => options.MapFrom(from => from.Cpf))
                .ForMember(dest => dest.Email, options => options.MapFrom(from => from.Email));


            CreateMap<UserDto, User>()
                .ForPath(dest => dest.Cpf, options => options.MapFrom(from => from.Cpf.ToString()))
                .ForPath(dest => dest.Email, options => options.MapFrom(from => from.Email.ToString()));
        }
    }
}
