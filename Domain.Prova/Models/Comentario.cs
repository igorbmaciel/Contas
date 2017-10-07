using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Prova.Models
{
    public class Comentario
    {    
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public virtual Perfil Perfil { get; set; }
        public int PerfilId { get; set; }
    }
}
