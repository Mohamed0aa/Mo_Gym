using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mo_Talabat_Core_Domain.Contract;
using Mo_Talabat_Infrastructure_presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection Addpresistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>((optionbuilder) =>
            {
                //connection string
                optionbuilder.UseSqlServer(configuration.GetConnectionString("StoreConnection"));
            });
            services.AddScoped<IStoreContextInitializer, StoreContextInitializer>();
            services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork.UnitOfWork)); 
            services.AddScoped(typeof(ISaveChangesInterceptor),typeof(CustomSaveChangeInterceptor));
            return services;
        }
    }
}
