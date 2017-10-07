using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Application.ViewModels
{
    public class ContaViewModel
    {
        public ContaViewModel()
        {
            Perfis = new List<PerfilViewModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome do Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Senha { get; set; }

        public virtual ICollection<PerfilViewModel> Perfis { get; set; }
    }
}
