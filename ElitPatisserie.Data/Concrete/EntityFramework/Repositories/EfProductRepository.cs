using ElitPatisserie.Data.Abstract;
using ElitPatisserie.Data.Concrete.EntityFramework.Contexts;
using ElitPatisserie.Data.Concrete.EntityFramework.GenericRepository;
using ElitPatisserie.Entity.Abstract;
using ElitPatisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ElitPatisserie.Data.Concrete.EntityFramework.Repositories
{
    public class EfProductRepository : GenericDal<Product>, IProductRepository
    {
        private readonly ElitPatisserieContext _context;
        public EfProductRepository(ElitPatisserieContext context) : base(context)
        {
            _context = context;
        }

        public IList<Product> GetAll()
        {
            return _context.Products.Include(x=>x.Category).AsNoTrackingWithIdentityResolution().ToList();
        }

        public async Task<IList<Product>> GetByCategory(string name)
        {
            var result = _context.Products.Include(p => p.Category);
            if (name=="Kahvaltı")
            {
                return await result.Where(x=>x.Category.Name==name).AsNoTracking().ToListAsync();
            }
            else if (name == "Aperatif")
            {
                return await result.Where(x => x.Category.Name == name).AsNoTracking().ToListAsync();
            }
            else if (name == "Pasta")
            {
                return await result.Where(x => x.Category.Name == name).AsNoTracking().ToListAsync();
            }
            else if (name == "Tatlı")
            {
                return await result.Where(x => x.Category.Name == name).AsNoTracking().ToListAsync();
            }
            else if (name == "Içecek")
            {
                return await result.Where(x => x.Category.Name == name).AsNoTracking().ToListAsync();
            }
            else if (name == "Baklava")
            {
                return await result.Where(x => x.Category.Name == name).AsNoTracking().ToListAsync();
            }
            else
            {
                return await result.AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Product>> GetByCategoryWithId(int id)
        {
            var result = _context.Products.Include(p => p.Category);
            if (id == 1)
            {
                return await result.Where(x => x.Category.Id == id).AsNoTracking().ToListAsync();
            }
            else if (id == 2)
            {
                return await result.Where(x => x.Category.Id == id).AsNoTracking().ToListAsync();
            }
            else if (id == 3)
            {
                return await result.Where(x => x.Category.Id == id).AsNoTracking().ToListAsync();
            }
            else if (id == 4)
            {
                return await result.Where(x => x.Category.Id == id).AsNoTracking().ToListAsync();
            }
            else if (id == 5)
            {
                return await result.Where(x => x.Category.Id == id).AsNoTracking().ToListAsync();
            }
            else if (id == 6)
            {
                return await result.Where(x => x.Category.Id == id).AsNoTracking().ToListAsync();
            }
            else
            {
                return await result.AsNoTracking().ToListAsync();
            }
        }
    }
}
