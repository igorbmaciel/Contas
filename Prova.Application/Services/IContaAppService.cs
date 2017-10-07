using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prova.Application.ViewModels;

namespace Prova.Application.Services
{
    public interface IContaAppService : IDisposable
    {
        ContaPerfilViewModel Adicionar(ContaPerfilViewModel contaPerfilViewModel);
        ContaViewModel ObterPorId(int id);
        IEnumerable<ContaViewModel> ObterTodos();
        ContaViewModel Atualizar(ContaViewModel contaViewModel);
        void Remover(int id);

        PerfilViewModel AdicionarPerfil(PerfilViewModel perfilViewModel);
        PerfilViewModel AtualizarPerfil(PerfilViewModel perfilViewModel);
        IEnumerable<PerfilViewModel> ObterTodosPerfis();
        PerfilViewModel ObterPerfilPorId(int id);
        void RemoverPerfil(int id);
    }
}
