using AutoMapper;
using DbUserService.Models;
using SharedProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServices.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
        }
    }
}
