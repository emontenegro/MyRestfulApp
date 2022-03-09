using AutoMapper;
using MyRestfulApp.Domain.Models;
using MyRestfulApp.Infraestructure.DataContext.DbModels;
using System.Collections.Generic;

namespace MyRestfulApp.Domain.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
