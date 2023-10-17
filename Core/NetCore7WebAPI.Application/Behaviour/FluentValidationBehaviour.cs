using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application.Behaviour
{
    public class FluentValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public FluentValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var fails = validator.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(x => x != null)
                .ToList();

            if (fails.Any())
            {
                throw new ValidationException(fails);
            }

            return next();
        }
    }
}
