using ElitPatisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitPatisserie.Data.Concrete.EntityFramework.Mappings
{
    public class MenuSliderMap : IEntityTypeConfiguration<MenuSlider>
    {
        public void Configure(EntityTypeBuilder<MenuSlider> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.Price).IsRequired();
        }
    }
}
