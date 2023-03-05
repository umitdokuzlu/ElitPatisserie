using ElitPatisserie.Data.Concrete.EntityFramework.GenericRepository;
using ElitPatisserie.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Data.Abstract
{
    public interface IChefRepository:IGenericDal<Chef>
    {
    }
}
