using Domain.Prova.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Data.ContextConfig
{
    public class ComentarioContextConfig : EntityTypeConfiguration<Comentario>
    {
        public ComentarioContextConfig()
        {
            ToTable("Comentario");
            HasKey(x => x.Id);

            Property(c => c.Comentarios)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(c => c.Perfil)
              .WithMany(p => p.Comentarios)
              .HasForeignKey(e => e.PerfilId);
        }
    }
}
