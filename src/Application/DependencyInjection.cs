using System;
using Application.admin;
using Application.Helpers;
using Data.admin;
using Data.client;
using Data.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using AccountDal = Data.admin.AccountDal;
using ClientAccountDal = Data.client.AccountDal;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IFileManager,FileManager>();
            services.AddSingleton<DataAccessLayer>();
            services.AddSingleton<AccountDal>();
            services.AddSingleton<ClientAccountDal>();
            services.AddSingleton<AccountManager>();
            services.AddSingleton<CategoryDal>();
            services.AddSingleton<CategoryManager>();
            services.AddSingleton<ProductDal>();
            services.AddSingleton<ProductManager>();
            services.AddSingleton<ProductsDal>();
            services.AddSingleton<client.ProductManager>();
            services.AddSingleton<client.AccountManager>();
        }
    }
}