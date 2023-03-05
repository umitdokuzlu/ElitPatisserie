using ElitPatisserie.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Business.Abstract
{
    public interface IUserService:IGenericService<User>
    {
        Task<User> GetByUser(User user);
    }
}
