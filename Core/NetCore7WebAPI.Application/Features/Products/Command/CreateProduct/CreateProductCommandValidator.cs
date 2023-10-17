using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {

        public CreateProductCommandValidator()
        {

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Ürünü Adı");


            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Fiyat");

            RuleFor(x => x.Discount)
               .GreaterThanOrEqualTo(0)
               .WithName("İndirim");

            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Marka");

            RuleFor(x => x.CategoryIds)
                .Must(x => x.Any())
                .WithName("Kategoriler");


        }
    }
}
