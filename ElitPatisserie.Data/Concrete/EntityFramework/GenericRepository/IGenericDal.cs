using ElitPatisserie.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Data.Concrete.EntityFramework.GenericRepository
{
    public interface IGenericDal<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
