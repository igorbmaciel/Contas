using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Prova.Models;

namespace Prova.Application.ViewModels
{
    public class PerfilViewModel
    {
        public PerfilViewModel()
        {
            Publicacoes = new List<Publicacao>();
            Comentarios = new List<Comentario>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Local")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Local { get; set; }

        public virtual ContaViewModel Conta { get; set; }
        public int ContaId { get; set; }
        public virtual ICollection<Publicacao> Publicacoes { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
