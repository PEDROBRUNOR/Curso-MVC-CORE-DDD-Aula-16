using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Domain.Shared.Entidades;
using Projeto.Curso.Core.Infra.Data.Context;

namespace Projeto.Curso.Core.Infra.Data.Repository
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : EntidadeBase
    {
        protected ContextEFPedidos Db;
        protected DbSet<TEntidade> DbSet;

        public Repository(ContextEFPedidos context)
        {
            Db = context;
        }

        public virtual void Adicionar(TEntidade obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntidade obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remover(TEntidade obj)
        {
            DbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }

}
