using ElitPatisserie.Data.Concrete.EntityFramework.GenericRepository;
using ElitPatisserie.Entity.Abstract;
using ElitPatisserie.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Data.Abstract
{
    public interface IProductRepository:IGenericDal<Product>
    {
        Task<IList<Product>> GetByCategory(string name);
        Task<IList<Product>> GetByCategoryWithId(int id);
        IList<Product> GetAll();
    }
}
