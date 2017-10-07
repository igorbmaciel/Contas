using Domain.Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Prova.Repositories
{
    public interface IContaRepository : IDisposable
    {
        Conta Adicionar(Conta conta);
        Conta ObterPorId(int id);
        IEnumerable<Conta> ObterTodos();
        void Atualizar(Conta conta);
        void Remover(int id);
    }
}
