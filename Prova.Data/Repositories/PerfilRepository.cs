using Domain.Prova.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Prova.Models;
using Prova.Data.Context;

namespace Prova.Data.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        protected ProvaContext Db = new ProvaContext();

        public void AdicionarPerfil(Perfil perfil)
        {
            Db.Set<Perfil>().Add(perfil);
            Db.SaveChanges();
        }

        public void AtualizarPerfil(Perfil perfil)
        {
            Db.Set<Perfil>().Attach(perfil);
            Db.SaveChanges();
        }

        public IEnumerable<Perfil> ObterTodosPerfis()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Perfil pe " +
                      "LEFT JOIN Publicacao pu " +
                      "ON pu.PerfilId = pe.Id " +
                      "LEFT JOIN Comentario co " +
                      "ON co.PerfilId = pe.Id ";

            var perfil = new List<Perfil>();
            cn.Query<Perfil, Publicacao, Comentario, Perfil>(sql,
                (p, e, c) =>
                {
                    perfil.Add(p);
                    if (e != null)
                        perfil[0].Publicacoes.Add(e);

                    if (c != null)
                        perfil[0].Comentarios.Add(c);

                    return perfil.FirstOrDefault();
                }, new {}, splitOn: "Id, Id");

            return perfil;
        }

        public Perfil ObterPerfilPorId(int id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Perfil pe " +
                      "LEFT JOIN Publicacao pu " +
                      "ON pu.PerfilId = pe.Id " +
                      "WHERE pe.Id = @sid";

            var perfil = new List<Perfil>();
            cn.Query<Perfil, Publicacao, Perfil>(sql,
                (p, e) =>
                {
                    perfil.Add(p);
                    if (e != null)
                        perfil[0].Publicacoes.Add(e);

                    return perfil.FirstOrDefault();
                }, new { sid = id }, splitOn: "Id, Id");

            var sql2 = @"SELECT * FROM Perfil pe " +
                       "LEFT JOIN Comentario co " +
                       "ON co.PerfilId = pe.Id " +
                      "WHERE pe.Id = @sid";
           
            cn.Query<Perfil,  Comentario, Perfil>(sql2,
                (p, c) =>
                {
                    perfil.Add(p);

                    if (c != null)
                        perfil[0].Comentarios.Add(c);

                    return perfil.FirstOrDefault();
                }, new { sid = id }, splitOn: "Id, Id");

           

            return perfil.FirstOrDefault();
        }

        public void RemoverPerfil(int id)
        {
            Db.Set<Perfil>().Remove(Db.Set<Perfil>().Find(id));
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
