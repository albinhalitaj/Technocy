using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            var customers = con.QueryAsync<Customer>(sql, commandType: CommandType.StoredProcedure).Result;
            return customers;
        }
    }
}