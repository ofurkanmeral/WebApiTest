using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.ToTable("Ürünler");

            //Bu şu demek toplam 18 rakam olsun ama virgülden sonrası 2 karakter olsun yani
            //111111111111111,11  yani 16 rakam virgülün solunda 2 rakam virgülün sağında
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);

        }
    }
}
