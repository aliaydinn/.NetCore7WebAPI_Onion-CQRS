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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {

            Faker faker = new("tr");
            Detail detail = new()
            {
                Id = 1,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                IsDeleted = false
            };
            Detail detail1 = new()
            {
                Id = 2,
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                IsDeleted = true
            };
            Detail detail2 = new()
            {
                Id = 3,
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                IsDeleted = false
            };

            builder.HasData(detail, detail1, detail2);
        }
    }
}
