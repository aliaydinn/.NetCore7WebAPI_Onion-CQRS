using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore7WebAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
