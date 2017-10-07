using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Prova.Models;
using Prova.Application.ViewModels;

namespace Prova.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Conta, ContaViewModel>();
            CreateMap<Conta, ContaPerfilViewModel>();
            CreateMap<Perfil, PerfilViewModel>();
            CreateMap<Perfil, ContaPerfilViewModel>();
        }
    }
}
