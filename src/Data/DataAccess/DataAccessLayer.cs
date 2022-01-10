using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Data.DataAccess
{
    public class DataAccessLayer
    {
        private readonly IConfiguration _configuration;

        public DataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public SqlConnection AppConn()
        {
            var conString =  _configuration.GetConnectionString("winCon");
            var con = new SqlConnection(conString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
    }
}