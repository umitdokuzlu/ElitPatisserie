using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.Abstract
{
    public interface IGenericService<T> where T : class,new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AnyAsync(int id);
    }
}
