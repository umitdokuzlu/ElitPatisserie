using ElitPatisserie.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Entity.Concrete
{
    public class HomeSlider:IEntity
    {
        public int Id { get; set; }
        public string Picture { get; set; }

    }
}
