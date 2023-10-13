using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandRequest :IRequest
    {
        public int Id { get; set; }
    }
}
