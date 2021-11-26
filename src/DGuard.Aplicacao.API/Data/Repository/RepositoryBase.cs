using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DGuard.Core.DomainObjects;
using System.Linq.Expressions;
using DGuard.Core.Data;

namespace DGuard.Aplicacao.API.Data.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> DbSet;

        public IUnitOfWork UnitOfWork => _context;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }
        public void Create(T model)
        {
            DbSet.Add(model);
        }

        public void Update(T model)
        {
            DbSet.Update(model);
        }

        public void Delete(T model)
        {
            DbSet.Remove(model);

        }
        public async Task<bool> Exist(Guid id)
        {
            return await DbSet.AnyAsync(x => x.Id == id);
        }

        public virtual async Task<T> GetForId(Guid Id)
        {
            return await DbSet.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}