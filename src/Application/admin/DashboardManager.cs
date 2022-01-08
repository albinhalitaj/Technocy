using System.Collections.Generic;
using Data.admin;
using Domain.Entities;

namespace Application.admin
{
    public class DashboardManager
    {
        private readonly DashboardDal _dashboardDal;

        public DashboardManager(DashboardDal dashboardDal)
        {
            _dashboardDal = dashboardDal;
        }

        public int CustomerCount() => _dashboardDal.GetCustomerCount();

        public decimal GetTotal() => _dashboardDal.TotalProfit();

        public decimal GetAverage() => _dashboardDal.AverageProfit();

        public List<Order> GetOrders() => _dashboardDal.GetOrders();
        public int TotalProducts() => _dashboardDal.TotalProducts();

        public ChartDataViewModel GetChartData() => _dashboardDal.ChartData();
    }
}