using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetCore7WebAPI.Application.Bases;
using NetCore7WebAPI.Application.Behavior;
using NetCore7WebAPI.Application.Exceptions;
using NetCore7WebAPI.Application.Features.Products.Rules;
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
            services.AddRulesAssemblyContaining(assembly, typeof(BaseRules));


            services.AddMediatR(app => app.RegisterServicesFromAssemblies(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }

        private static IServiceCollection AddRulesAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(x => x.IsSubclassOf(type) && type != x).ToList();
            foreach (var item in types)
                services.AddTransient(item);
            return services;
        }
    }
}
