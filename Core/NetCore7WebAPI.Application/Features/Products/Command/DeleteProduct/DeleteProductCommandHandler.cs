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

namespace NetCore7WebAPI.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseHandler,IRequestHandler<DeleteProductCommandRequest,Unit>
    {

        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            
        }
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product=await unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id== request.Id && !x.IsDeleted);
            product.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
