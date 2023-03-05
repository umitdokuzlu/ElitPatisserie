using ElitPatisserie.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Entity.Concrete
{
    public class MenuSlider:IEntity
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string Name { get; set; }
        [MinLength(60)]
        public string Description { get; set; }
        public int Price { get; set; }
        public string Class { get; set; }

    }
}
