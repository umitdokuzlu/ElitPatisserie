using ElitPatisserie.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Entity.Concrete
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
