using ElitPatisserie.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Entity.Concrete
{
    public class Chef:IEntity
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string Name { get; set; }
        [MinLength(5)]
        public string Title { get; set; }
        public string Picture { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}
