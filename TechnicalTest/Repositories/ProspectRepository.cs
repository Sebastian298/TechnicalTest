using Dapper;
using System.Data;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;
using TechnicalTest.Services;

namespace TechnicalTest.Repositories
{
    public class ProspectRepository : IProspectRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDapperService _service;

        public ProspectRepository(IConfiguration configuration,IDapperService dapperService)
        {
            _configuration = configuration;
            _service = dapperService;
        }
        public async Task<GenericResponse<List<Prospect>>> GetAllProspectsAsync()
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:ProspectRepository:GetAll:Data");
                var result = await _service.ExecuteStoredProcedureAsync<Prospect>(spData, null, true);
                if (result.HasError)
                {
                    var error = MessageErrorBuilder.GenerateError(result.Message);
                    return new GenericResponse<List<Prospect>>() { StatusCode = 500, Message = error };
                }
                return new GenericResponse<List<Prospect>>()
                {
                    StatusCode = 200,
                    Content = result.Results
                };
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return new GenericResponse<List<Prospect>>() { StatusCode = 500, Message = message };
            }
        }
    }
}
