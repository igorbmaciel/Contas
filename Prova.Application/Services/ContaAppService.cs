using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Prova.Models;
using Domain.Prova.Services;
using Prova.Application.ViewModels;
using Prova.Data.UoW;

namespace Prova.Application.Services
{
    public class ContaAppService : ApplicationService, IContaAppService
    {
        private readonly IContaService _contaService;

        public ContaAppService(IContaService contaService, IUnitOfWork uow) : base(uow)
        {
            _contaService = contaService;
        }

        public ContaPerfilViewModel Adicionar(ContaPerfilViewModel contaperfilViewModel)
        {
            var conta = Mapper.Map<ContaPerfilViewModel, Conta>(contaperfilViewModel);
            var perfil = Mapper.Map<ContaPerfilViewModel, Perfil>(contaperfilViewModel);

            conta.Perfis.Add(perfil);

            BeginTransaction();

            var contaReturn = _contaService.Adicionar(conta);
            contaperfilViewModel = Mapper.Map<Conta, ContaPerfilViewModel>(contaReturn);
           
            Commit();

            return contaperfilViewModel;
        }

        public ContaViewModel ObterPorId(int id)
        {
            return Mapper.Map<Conta, ContaViewModel>(_contaService.ObterPorId(id));
        }

        public IEnumerable<ContaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Conta>, IEnumerable<ContaViewModel>>(_contaService.ObterTodos());
        }

        public ContaViewModel Atualizar(ContaViewModel contaViewModel)
        {
            BeginTransaction();
            _contaService.Atualizar(Mapper.Map<ContaViewModel, Conta>(contaViewModel));
            Commit();
            return contaViewModel;
        }

        public void Remover(int id)
        {
            BeginTransaction();
            _contaService.Remover(id);
            Commit();
        }

        public PerfilViewModel AdicionarPerfil(PerfilViewModel perfilViewModel)
        {
            var perfil = Mapper.Map<PerfilViewModel, Perfil>(perfilViewModel);

            BeginTransaction();
            _contaService.AdicionarPerfil(perfil);
            Commit();

            return perfilViewModel;
        }

        public PerfilViewModel AtualizarPerfil(PerfilViewModel perfilViewModel)
        {
            var perfil = Mapper.Map<PerfilViewModel, Perfil>(perfilViewModel);

            BeginTransaction();
            _contaService.AtualizarPerfil(perfil);
            Commit();

            return perfilViewModel;
        }

        public IEnumerable<PerfilViewModel> ObterTodosPerfis()
        {
            return Mapper.Map<IEnumerable<Perfil>, IEnumerable<PerfilViewModel>>(_contaService.ObterTodosPerfis());
        }

        public PerfilViewModel ObterPerfilPorId(int id)
        {
            return Mapper.Map<Perfil, PerfilViewModel>(_contaService.ObterPerfilPorId(id));
        }

        public void RemoverPerfil(int id)
        {
            BeginTransaction();
            _contaService.RemoverPerfil(id);
            Commit();
        }

        public void Dispose()
        {
            _contaService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}

