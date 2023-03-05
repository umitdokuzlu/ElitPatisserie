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

namespace ElitPatisserie.Data.Concrete.EntityFramework.Repositories
{
    public class EfUserRepository : GenericDal<User>, IUserRepository
    {
        private readonly ElitPatisserieContext _context;
        public EfUserRepository(ElitPatisserieContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUser(Expression<Func<User, bool>> predicate)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(predicate);
        }
    }
}
