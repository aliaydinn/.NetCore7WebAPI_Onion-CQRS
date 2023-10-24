using NetCore7WebAPI.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Products.Exceptions
{
    public class ProductNameCannotBeTheSameException :BaseExceptions
    {
        public ProductNameCannotBeTheSameException() :base("Ürünün ismi aynı olamaz !")
        {
            
        }
    }
}
