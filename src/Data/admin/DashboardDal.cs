using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.DataAccess;
using Domain.Entities;

namespace Data.admin
{
    public class DashboardDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public DashboardDal(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public int GetCustomerCount()
        {
            const string sql = "usp_GetCustomerCount";
            using var con = _dataAccessLayer.AppConn();
            var customerCount = con.QueryAsync<int>(sql, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return customerCount;
        }

        public decimal TotalProfit()
        {
            const string sql = "usp_TotalProfit";
            using var con = _dataAccessLayer.AppConn();
            var total = con.QueryFirst<decimal>(sql, commandType: CommandType.StoredProcedure);
            return total;
        }

        public decimal AverageProfit()
        {
            const string sql = "usp_AverageProfit";
            using var con = _dataAccessLayer.AppConn();
            var average = con.QueryFirst<decimal>(sql,commandType: CommandType.StoredProcedure);
            return average;
        }

        public List<Order> GetOrders()
        {
            const string sql = "usp_GetOrders";
            using var con = _dataAccessLayer.AppConn();
            var orders = con.Query<Order>(sql, commandType: CommandType.StoredProcedure).ToList();
            return orders;
        }

        public int TotalProducts()
        {
            const string sql = "usp_TotalProducts";
            using var con = _dataAccessLayer.AppConn();
            var products = con.Query<int>(sql, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return products;
        }

        public ChartDataViewModel ChartData()
        {
            const string sql = "usp_GetChartData";
            using var con = _dataAccessLayer.AppConn();
            var charData = con.QueryFirstOrDefault<ChartDataViewModel>(sql, commandType: CommandType.StoredProcedure);
            return charData;
        }
    }

    public class ChartDataViewModel
    {
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal July { get; set; }
        public decimal June { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
    }
}