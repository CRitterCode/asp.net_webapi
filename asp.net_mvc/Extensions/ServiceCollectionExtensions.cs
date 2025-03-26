using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace asp.net_mvc.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InitializeDatabase(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DatabaseConnection")
                ?? throw new DatabaseException("Can't initialize Database");

            services.AddDbContext<ReservationDbContext>(options =>
                options.UseSqlite(connectionString));

            return services;
        }

        public static IServiceCollection InitializeIdentityDatabase(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("IdentityDatabaseConnection")
                ?? throw new DatabaseException("Can't initialize identity database");

            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlite(connectionString));

            return services;
        }

        public static IServiceCollection AddAutoMapper(
            this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }


    }
}
