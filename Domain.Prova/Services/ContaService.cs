using Domain.Prova.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Prova.Models;

namespace Domain.Prova.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _ContaRepository;
        private readonly IPerfilRepository _PerfilRepository;

        public ContaService(IContaRepository ContaRepository, IPerfilRepository PerfilRepository)
        {
            _ContaRepository = ContaRepository;
            _PerfilRepository = PerfilRepository;

        }

        public Conta Adicionar(Conta conta)
        {
            return _ContaRepository.Adicionar(conta);
        }

        public void AdicionarPerfil(Perfil perfil)
        {
            _PerfilRepository.AdicionarPerfil(perfil);
        }

        public void Atualizar(Conta conta)
        {
            _ContaRepository.Atualizar(conta);
        }

        public void AtualizarPerfil(Perfil perfil)
        {
            _PerfilRepository.AtualizarPerfil(perfil);
        }

        public IEnumerable<Perfil> ObterTodosPerfis()
        {
            return _PerfilRepository.ObterTodosPerfis();
        }

        public Perfil ObterPerfilPorId(int id)
        {
            return _PerfilRepository.ObterPerfilPorId(id);
        }

        public Conta ObterPorId(int id)
        {
            return _ContaRepository.ObterPorId(id);
        }

        public IEnumerable<Conta> ObterTodos()
        {
            return _ContaRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            _ContaRepository.Remover(id);
        }

        public void RemoverPerfil(int id)
        {
            _PerfilRepository.RemoverPerfil(id);
        }

        public void Dispose()
        {
            _ContaRepository.Dispose();
            _PerfilRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
