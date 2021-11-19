using Application.admin;
using Data.admin;
using Data.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependecyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<DataAccessLayer>();
            services.AddSingleton<AccountDal>();
            services.AddSingleton<AccountManager>();
        }
    }
}