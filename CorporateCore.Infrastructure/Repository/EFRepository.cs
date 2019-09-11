using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CorporateCore.Infrastructure.Repository
{
    /// <summary>
    /// Implementação para EntityFrameworkCore
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CorporateContext _dbContext;
        public EFRepository(CorporateContext contaContext)
        {
            _dbContext = contaContext;
        }
        public virtual TEntity Adicionar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;

        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return _dbContext.Set<TEntity>().Where(predicado).AsEnumerable();
        }

        public virtual TEntity ObterPorID(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public void Remover(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
