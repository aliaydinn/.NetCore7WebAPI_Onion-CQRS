using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore7WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new {x.ProductId, x.CategoryId});

            builder.HasOne(x=>x.Product).WithMany(a=>a.ProductCategories).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Category).WithMany(a=>a.ProductCategories).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
