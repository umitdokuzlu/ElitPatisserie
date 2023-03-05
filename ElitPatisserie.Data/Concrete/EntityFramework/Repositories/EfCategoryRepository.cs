using ElitPatisserie.Data.Abstract;
using ElitPatisserie.Data.Concrete.EntityFramework.Contexts;
using ElitPatisserie.Data.Concrete.EntityFramework.GenericRepository;
using ElitPatisserie.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : GenericDal<Category>, ICategoryRepository
    {
        private readonly ElitPatisserieContext _context;
        public EfCategoryRepository(ElitPatisserieContext context) : base(context)
        {
            _context = context;
        }

        public IList<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
