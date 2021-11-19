using System.Data;
using System.Linq;
using Dapper;
using Data.admin.Helpers;
using Data.DataAccess;
using Domain.Entities;

namespace Data.admin
{
    public class AccountDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public AccountDal(DataAccessLayer dataAccessLayer)
        {
            this._dataAccessLayer = dataAccessLayer;
        }

        public Employee Login(string username, string password)
        {
            using var con = _dataAccessLayer.AppConn();
            const string sql = "usp_GetEmployee";
            var values = new {username, password = EncodeBase64.Base64Encode(password)};
            var result = con.Query<Employee,Role,Employee>(sql,(emp,role) =>
                {
                    emp.Role = role;
                    return emp;
                },values,splitOn: "Name",commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return result;
        }
    }
}