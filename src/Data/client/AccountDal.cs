using System.Data;
using Dapper;
using Data.admin.Helpers;
using Data.DataAccess;
using Domain.Entities;

namespace Data.client
{
    public class AccountDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public AccountDal(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public bool Register(Customer customer)
        {
            const string sql = "usp_InsertCustomer";
            using var con = _dataAccessLayer.AppConn();
            var values = new
            {
                name = customer.Name,
                surname = customer.Surname,
                email = customer.Email,
                passwordHash = customer.PasswordHash,
                birthdate = customer.Birthdate,
                address = customer.Address,
                city = customer.City,
                country = customer.Country,
                postalCode = customer.PostalCode,
                phone = customer.Phone,
                insertDate = customer.InsertDate
            };
            var rowsAffected = con.Execute(sql, values, commandType: CommandType.StoredProcedure);
            return rowsAffected == 1;
        }

        public Customer Login(string email,string password)
        {
            const string sql = "usp_GetCustomer";
            using var con = _dataAccessLayer.AppConn();
            var values = new
            {
                email,
                passwordHash = EncodeBase64.Base64Encode(password)
            };
            var customer = con.QueryFirstOrDefault<Customer>(sql, values, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public Customer GetCustomer(int id)
        {
            const string sql = "usp_GetCustomerById";
            using var con = _dataAccessLayer.AppConn();
            var customer = con.QueryFirstOrDefault<Customer>(sql, new {id}, commandType: CommandType.StoredProcedure);
            return customer;
        }
    }
}