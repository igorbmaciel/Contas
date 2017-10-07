using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Prova.Repositories;
using Domain.Prova.Services;
using Prova.Application.Services;
using Prova.Data.Context;
using Prova.Data.Repositories;
using Prova.Data.UoW;
using SimpleInjector;

namespace Prova.CrossCutting_IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<IContaAppService, ContaAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IContaService, ContaService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IContaRepository, ContaRepository>(Lifestyle.Scoped);
            container.Register<IPerfilRepository, PerfilRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ProvaContext>(Lifestyle.Scoped);

            //container.Register(typeof (IRepository<>), typeof (Repository<>));
        }
    }
}
