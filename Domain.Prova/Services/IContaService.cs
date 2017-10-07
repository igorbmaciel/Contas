using Domain.Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Prova.Services
{
    public interface IContaService : IDisposable
    {
        Conta Adicionar(Conta conta);
        Conta ObterPorId(int id);       
        IEnumerable<Conta> ObterTodos();
        void Atualizar(Conta conta);
        void Remover(int id);

        void AdicionarPerfil(Perfil perfil);
        void AtualizarPerfil(Perfil perfil);
        IEnumerable<Perfil> ObterTodosPerfis();
        Perfil ObterPerfilPorId(int id);
        void RemoverPerfil(int id);
    }
}
