using Dapper;
using TechnicalTest.Models.Services;

namespace TechnicalTest.Services
{
    public interface IDapperService
    {
        Task<dynamic> ExecuteStoredProcedureAsync<T>(StoredProcedureData qData, DynamicParameters parameters, bool hasArray = false);
    }
}
