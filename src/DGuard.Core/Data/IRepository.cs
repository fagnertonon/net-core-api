using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DGuard.Core.DomainObjects;

namespace DGuard.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        Task<T> GetForId(Guid Id);
        Task<bool> Exist(Guid Id);
        Task<IEnumerable<T>> GetAll();

        Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate);

    }
}