using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Prova.Models
{
    public class Publicacao
    {       
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public virtual Perfil Perfil { get; set; }
        public int PerfilId { get; set; }
    }
}
