using Core;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Repository.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataContext:DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        //Direk product üzerinden ekleyeceğiz
        public DbSet<ProductFeature> productFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Her katman bir Assambyledir 
            //Burda şunu diyoruz git Bu(Repository) assemblyde ki IEntityConfigurations dosyalarını oku ve configure et
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Böyle Tek Tek manuel kullanımıda söz konusu
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            //BestPratice için buraya yazmıyoeuz örnek olsun diye yazdım Seed klasörüne bak
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                ID=1,
                Color = "mavi",
                ProductId = 1
            },
            new ProductFeature()
            {
                ID=2,
                Color="kırmızı",
                ProductId=2
            });
            
            //modelBuilder.ApplyConfiguration(new ProductSeed());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
            base.OnModelCreating(modelBuilder);
        }
    }
}














