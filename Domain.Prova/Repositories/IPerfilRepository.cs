using Domain.Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Prova.Repositories
{
    public interface IPerfilRepository : IDisposable
    {
        void AdicionarPerfil(Perfil perfil);
        void AtualizarPerfil(Perfil perfil);
        IEnumerable<Perfil> ObterTodosPerfis();
        Perfil ObterPerfilPorId(int id);
        void RemoverPerfil(int id);
    }
}
