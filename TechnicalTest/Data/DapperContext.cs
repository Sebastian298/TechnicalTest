using System.Data;
using System.Data.SqlClient;

namespace TechnicalTest.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection(string connectionName) => new SqlConnection(_configuration[$"ConnectionStrings:{connectionName}"]);
    }
}
