using UserManagement.DataLayer;
using UserManagement.DataLayer.Repositories;
using UserManagement.Infrastructure;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Infrastructure.Services;
using UserManagement.Managers;
using UserManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace UserManagement.Config
{
    public class MiddlewareConfiguration
    {
        public static void ConfigureEf(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            //services.AddEntityFrameworkNpgsql()
            //    .AddDbContext<DataContext>(
            //        options => options.UseNpgsql(connectionString));
        }
        public static void ConfigureUow(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureManager(IServiceCollection services)
        {
           
            services.AddScoped<IEmailManager, EmailManager>();
            
            services.AddScoped<IUserAccessMAnager, UserAccessManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRoleManager, UserRoleManager>();
            


        }
        public static void ConfigureRepository(IServiceCollection services)
        {


            services.AddScoped<IUserAccessRepository, UserAccessRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();


        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
