using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetCore7WebAPI.Application.Behaviour;
using NetCore7WebAPI.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddMediatR(app => app.RegisterServicesFromAssemblies(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture=new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
        }
    }
}
