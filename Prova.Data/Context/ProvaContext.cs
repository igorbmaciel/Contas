using Domain.Prova.Models;
using Prova.Data.ContextConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.Data.Context
{
    public class ProvaContext : DbContext
    {       

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public ProvaContext() : base("Name=BD_Prova")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ContaContextConfig());
            modelBuilder.Configurations.Add(new PerfilContextConfig());
            modelBuilder.Configurations.Add(new PublicacaoContextConfig());
            modelBuilder.Configurations.Add(new ComentarioContextConfig());

        }       
    }
    
}
