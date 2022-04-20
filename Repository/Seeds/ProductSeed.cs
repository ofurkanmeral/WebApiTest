using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            for (int i = 1; i < 10; i++)
            {
                builder.HasData(new Product()
                {
                    ID = i,
                    Name = $"Product{i}",
                    Price = Convert.ToInt32($"{i}00"),
                    CreatedDate = DateTime.Now,
                    Stock = Convert.ToInt32($"{i}0"),
                    CategoryID = 1
                });
            }
        }
    }
}
