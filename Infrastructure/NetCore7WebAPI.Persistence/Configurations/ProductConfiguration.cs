using Bogus;
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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("tr");

            Product product = new()
            {
                Id = 1,
                BrandId = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                Discount = faker.Random.Decimal(1, 10),
                Price = faker.Finance.Amount(10, 100),
                IsDeleted = false
            };
            Product product1 = new()
            {
                Id = 2,
                BrandId = 3,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                Discount = faker.Random.Decimal(1, 10),
                Price = faker.Finance.Amount(10, 100),
                IsDeleted = false
            };

            builder.HasData(product, product1);
        }
    }
}
