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
    public class EfChefRepository : GenericDal<Chef>, IChefRepository
    {
        public EfChefRepository(ElitPatisserieContext context) : base(context)
        {
        }
    }
}
