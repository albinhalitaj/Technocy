using System;
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<DataAccessLayer>();
            services.AddSingleton<AccountDal>();
            services.AddSingleton<AccountManager>();
            services.AddSingleton<CategoryDal>();
            services.AddSingleton<CategoryManager>();
        }
    }
}