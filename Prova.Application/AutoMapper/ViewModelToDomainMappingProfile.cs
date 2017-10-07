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
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ContaViewModel, Conta>();
            CreateMap<ContaPerfilViewModel, Conta>();
            CreateMap<PerfilViewModel, Perfil>();
            CreateMap<ContaPerfilViewModel, Perfil>();
        }
    }
}
