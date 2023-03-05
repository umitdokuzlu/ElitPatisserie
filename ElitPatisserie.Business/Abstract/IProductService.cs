using ElitPatisserie.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        Task<IList<Product>> GetByCategory(string name);
        Task<IList<Product>> GetByCategoryWithId(int id);
        IList<Product> GetAll();
    }
}
