using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ServicesLayer.Contracts;
using ServicesLayer.Services;

namespace ServicesLayer
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServicesLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductsServices, ProductsServices>();
            //services.AddScoped<IReviewService, ReviewServices>();
            return services;
        }
    }
}
