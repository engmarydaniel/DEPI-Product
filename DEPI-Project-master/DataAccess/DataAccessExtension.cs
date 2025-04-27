using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services/*, IConfiguration configuration*/)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ProductRepository>();
           // services.AddScoped<IReviewRepository, ReviewRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();



            //services.AddDbContext<e_commerce_DbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("e_commerce_connstring")));

            return services;

        }
    }
}
