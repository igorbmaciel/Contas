using Domain.Prova.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Data.ContextConfig
{
    public class PublicacaoContextConfig : EntityTypeConfiguration<Publicacao>
    {
        public PublicacaoContextConfig()
        {
            ToTable("Publicacao");
            HasKey(x => x.Id);

            Property(p => p.Conteudo)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(p => p.Perfil)
              .WithMany(c => c.Publicacoes)
              .HasForeignKey(e => e.PerfilId);
        }
    }
}
