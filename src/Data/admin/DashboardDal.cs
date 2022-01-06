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
    }
}