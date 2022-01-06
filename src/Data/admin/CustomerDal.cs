using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.DataAccess;
using Domain.Entities;

namespace Data.admin
{
    public class CustomerDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public CustomerDal(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            const string sql = "usp_GetCustomers";
            using var con = _dataAccessLayer.AppConn();
            var customers = con.QueryAsync<Customer>(sql, commandType: CommandType.StoredProcedure).Result.ToList();
            if (!customers.Any()) return customers;
            foreach (var customer in customers)
            {
                customer.Total = GetCustomerTotal(customer.CustomerId);
            }
            return customers;
        }

        private decimal? GetCustomerTotal(int customerId)
        {
            const string sql = "usp_GetCustomerTotal";
            using var con = _dataAccessLayer.AppConn();
            var total = con.QueryFirst<decimal?>(sql, new {customerId}, commandType: CommandType.StoredProcedure);
            return total;
        }
    }
}