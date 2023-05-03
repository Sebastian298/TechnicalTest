using Dapper;
using System.Data;
using TechnicalTest.Data;
using TechnicalTest.Models.Services;

namespace TechnicalTest.Services
{
    public class DapperService : IDapperService
    {
        private readonly DapperContext _context;

        public DapperService(DapperContext context)
        {
            _context = context;
        }
        public async Task<dynamic> ExecuteStoredProcedureAsync<T>(StoredProcedureData qData, DynamicParameters parameters, bool hasArray = false)
        {
            try
            {
                var spName = $"{qData.SchemaName}.{qData.Name}";
                using (IDbConnection connection = _context.CreateConnection(qData.IdConnectionString))
                {
                    dynamic response;
                    if (hasArray)
                    {
                        response = await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);

                    }
                    else
                    {
                        response = await connection.QuerySingleOrDefaultAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Se produjo un error al ejecutar el stored procedure", ex);
            }
        }
    }
}
