using MediatR;
using Microsoft.AspNetCore.Http;
using NetCore7WebAPI.Application.Bases;
using NetCore7WebAPI.Application.Features.Products.Rules;
using NetCore7WebAPI.Application.Interfaces.AutoMapper;
using NetCore7WebAPI.Application.Interfaces.UnitOfWorks;
using NetCore7WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler :BaseHandler, IRequestHandler<CreateProductCommandRequest,Unit>
    {
       
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor,ProductRules productRules) : base(mapper,unitOfWork,httpContextAccessor) 
        {
            
            this.productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
            Product product = new(request.Title, request.Description, request.Price, request.Discount, request.BrandId);
            await productRules.ProductNameCannotBeTheSame(products, request.Title);
            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await unitOfWork.SaveAsync()>0)
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId=product.Id,
                        CategoryId=categoryId
                    });
                }

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
