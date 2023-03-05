using ElitPatisserie.Data.Concrete.EntityFramework.Mappings;
using ElitPatisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Data.Concrete.EntityFramework.Contexts
{
    public class ElitPatisserieContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<MenuSlider> MenuSliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-PP0P5FV\MSSQLSERVER01;database=ElitProjectDb;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ChefMap());
            modelBuilder.ApplyConfiguration(new MenuSliderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}
