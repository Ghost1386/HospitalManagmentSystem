using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.BusinessLogic.Services;
using HospitalManagmentSystem.DAL;
using HospitalManagmentSystem.DAL.Interfaces;
using HospitalManagmentSystem.DAL.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagmentSystem.BusinessLogic
{
    public static class Dependencies
    {
        public static void AddConnectionSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ConnectionSettings
            {
                ConnectionStr = configuration.GetConnectionString("DefaultConnection")
            });
        }

        public static void AddIRepository(this IServiceCollection services)
        {
            services.AddTransient<IRecordRepository, RecordRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthService, AuthService>();
        }
        
        public static void AddIService(this IServiceCollection services)
        {
            services.AddTransient<IRecordService, RecordService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}