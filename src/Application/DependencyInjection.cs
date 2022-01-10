using System;
using Application.admin;
using Application.client;
using Application.Helpers;
using Data.admin;
using Data.client;
using Data.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using AccountDal = Data.admin.AccountDal;
using AccountManager = Application.admin.AccountManager;
using ClientAccountDal = Data.client.AccountDal;
using ProductManager = Application.admin.ProductManager;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IFileManager,FileManager>();
            services.AddTransient<DataAccessLayer>();
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
            services.AddSingleton<CustomerDal>();
            services.AddSingleton<CustomerManager>();
            services.AddSingleton<WishlistDal>();
            services.AddSingleton<WishlistManager>();
            services.AddSingleton<DashboardDal>();
            services.AddSingleton<DashboardManager>();
            services.AddSingleton<OrderDal>();
            services.AddSingleton<OrderService>();
            services.AddSingleton<OrdersDal>();
            services.AddSingleton<OrderManager>();
        }
    }
}