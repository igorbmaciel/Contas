using Domain.Prova.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Data.ContextConfig
{
    public class ContaContextConfig : EntityTypeConfiguration<Conta>
    {
        public ContaContextConfig()
        {
            ToTable("Conta");
            HasKey(x => x.Id);

            Property(c => c.NomeUsuario)
              .IsRequired()
              .HasMaxLength(150);

            Property(c => c.Senha)
              .IsRequired()
              .HasMaxLength(100);
            
        }
    }
}
