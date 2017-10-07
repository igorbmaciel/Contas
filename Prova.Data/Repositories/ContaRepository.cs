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
    public class ContaRepository : IContaRepository
    {
        protected ProvaContext Db = new ProvaContext();

        public Conta Adicionar(Conta conta)
        {
            var objreturn = Db.Set<Conta>().Add(conta);
            Db.SaveChanges();
            return objreturn;
        }

        public void Atualizar(Conta conta)
        {
            var cn = Db.Database.Connection;
            var sql = @"UPDATE Conta " + $"SET NomeUsuario = '{conta.NomeUsuario}', Senha = '{conta.Senha}'" +
                      $"WHERE Id = {conta.Id}";

            cn.Execute(sql);
        }

        public Conta ObterPorId(int id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Conta c " +
                      "LEFT JOIN Perfil p " +
                      "ON p.ContaId = c.Id " +
                      "WHERE c.Id = @sid";

            var conta = new List<Conta>();
            cn.Query<Conta, Perfil, Conta>(sql,
                (c, e) =>
                {
                    conta.Add(c);
                    if (e != null)
                        conta[0].Perfis.Add(e);

                    return conta.FirstOrDefault();
                }, new { sid = id }, splitOn: "Id, Id");

            return conta.FirstOrDefault();
        }

        public IEnumerable<Conta> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Conta";

            return cn.Query<Conta>(sql);
        }

        public void Remover(int id)
        {
            var perfil = Db.Set<Perfil>().ToList();
            var perfilId = perfil.FirstOrDefault(p => p.ContaId == id).Id;

            var publicacoes = Db.Set<Publicacao>().Where(p => p.PerfilId == perfilId).ToList();

            for (int i = 0; i < publicacoes.Count(); i++)
            {
                var publicacoesId = publicacoes[i].Id;
                Db.Set<Publicacao>().Remove(Db.Set<Publicacao>().Find(publicacoesId));
            }

            var comentarios = Db.Set<Comentario>().Where(p => p.PerfilId == perfilId).ToList();

            for (int i = 0; i < comentarios.Count(); i++)
            {
                var comentariosId = comentarios[i].Id;
                Db.Set<Comentario>().Remove(Db.Set<Comentario>().Find(comentariosId));
            }

            Db.Set<Perfil>().Remove(Db.Set<Perfil>().Find(perfilId));
            Db.Set<Conta>().Remove(Db.Set<Conta>().Find(id));
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
