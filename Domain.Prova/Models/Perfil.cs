using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Prova.Models
{
    public class Perfil
    {
        public Perfil()
        {
            Publicacoes = new List<Publicacao>();
            Comentarios = new List<Comentario>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Local { get; set; }
        public virtual Conta Conta { get; set; }
        public int ContaId { get; set; }
        public virtual ICollection<Publicacao> Publicacoes { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
