using Dapper;
using TechnicalTest.Models.Responses;
using TechnicalTest.Models.Services;

namespace TechnicalTest.Services
{
    public interface IDapperService
    {
        Task<ServiceResponse> ExecuteStoredProcedureAsync<T>(StoredProcedureData qData, DynamicParameters parameters, bool hasArray = false);
    }
}
