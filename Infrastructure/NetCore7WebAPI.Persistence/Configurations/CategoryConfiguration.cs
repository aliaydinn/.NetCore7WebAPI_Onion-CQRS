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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category = new()
            {
                Id = 1,
                Name = "Elektronik",
                Priorty = 1,
                ParentId = 0,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            Category category1 = new()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            Category parent = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            Category parent1 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentId = 2,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };


            builder.HasData(category, category1, parent, parent1);
        }
    }
}
