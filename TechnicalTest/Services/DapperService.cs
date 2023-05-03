using Dapper;
using Newtonsoft.Json.Linq;
using System.Data;
using TechnicalTest.Data;
using TechnicalTest.Models.Responses;
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
        public async Task<ServiceResponse> ExecuteStoredProcedureAsync<T>(StoredProcedureData qData, DynamicParameters parameters, bool hasArray = false)
        {
            try
            {
                dynamic response;
                var spName = $"{qData.SchemaName}.{qData.Name}";
                using (IDbConnection connection = _context.CreateConnection(qData.IdConnectionString))
                {
                    
                    if (hasArray)
                    {
                        response = await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);

                    }
                    else
                    {
                        response = await connection.QuerySingleOrDefaultAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
                    }

                    return new ServiceResponse
                    {
                        Results = response
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    HasError = true,
                    Message = ex.Message,
                };
            }
        }
    }
}
