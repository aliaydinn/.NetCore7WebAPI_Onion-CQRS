using NetCore7WebAPI.Application.Bases;
using NetCore7WebAPI.Application.Features.Products.Exceptions;
using NetCore7WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Products.Rules
{
    public class ProductRules :BaseRules
    {
        public Task ProductNameCannotBeTheSame(IList<Product> products,string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle))
                throw new ProductNameCannotBeTheSameException();

            return Task.CompletedTask;
        }
    }
}
