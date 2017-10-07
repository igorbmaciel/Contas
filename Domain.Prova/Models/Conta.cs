using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Prova.Models
{
    public class Conta
    {
        public Conta()
        {
            Perfis = new List<Perfil>();
        }
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }       
        public virtual ICollection<Perfil> Perfis { get; set; }
    }
}
