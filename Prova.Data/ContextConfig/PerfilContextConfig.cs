using Domain.Prova.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Data.ContextConfig
{
    public class PerfilContextConfig : EntityTypeConfiguration<Perfil>
    {
        public PerfilContextConfig()
        {
            ToTable("Perfil");
            HasKey(x => x.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Local)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(e => e.Conta)
               .WithMany(c => c.Perfis)
               .HasForeignKey(e => e.ContaId);
        }
    }
}
