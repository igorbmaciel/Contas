namespace Prova.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comentarios = c.String(nullable: false, maxLength: 150, unicode: false),
                        PerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.PerfilId)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Local = c.String(nullable: false, maxLength: 150, unicode: false),
                        ContaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conta", t => t.ContaId)
                .Index(t => t.ContaId);
            
            CreateTable(
                "dbo.Conta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false, maxLength: 150, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publicacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Conteudo = c.String(nullable: false, maxLength: 150, unicode: false),
                        PerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.PerfilId)
                .Index(t => t.PerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "PerfilId", "dbo.Perfil");
            DropForeignKey("dbo.Publicacao", "PerfilId", "dbo.Perfil");
            DropForeignKey("dbo.Perfil", "ContaId", "dbo.Conta");
            DropIndex("dbo.Publicacao", new[] { "PerfilId" });
            DropIndex("dbo.Perfil", new[] { "ContaId" });
            DropIndex("dbo.Comentario", new[] { "PerfilId" });
            DropTable("dbo.Publicacao");
            DropTable("dbo.Conta");
            DropTable("dbo.Perfil");
            DropTable("dbo.Comentario");
        }
    }
}
