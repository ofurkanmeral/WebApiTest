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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category()
            {
                ID = 1,
                Name = "Category1",
                CreatedDate = DateTime.Now,
            },
            new Category()
            {
                ID = 2,
                Name = "Category2",
                CreatedDate = DateTime.Now,
            });
        }
    }
}
