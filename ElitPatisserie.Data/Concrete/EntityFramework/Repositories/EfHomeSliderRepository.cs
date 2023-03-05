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
    public class EfHomeSliderRepository : GenericDal<HomeSlider>, IHomeSliderRepository
    {
        public EfHomeSliderRepository(ElitPatisserieContext context) : base(context)
        {
        }
    }
}
