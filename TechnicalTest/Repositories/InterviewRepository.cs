using Dapper;
using System.Data;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;
using TechnicalTest.Services;

namespace TechnicalTest.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDapperService _dapperService;

        public InterviewRepository(IConfiguration configuration,IDapperService dapperService)
        {
            _configuration = configuration;
            _dapperService = dapperService;
        }
        public async Task<GenericResponse<List<Interview>>> GetAllInterviewsAsync()
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:InterviewRepository:GetAll:Data");
                var result = await _dapperService.ExecuteStoredProcedureAsync<Interview>(spData, null, true);
                if (result.HasError)
                {
                    var error = MessageErrorBuilder.GenerateError(result.Message);
                    return new GenericResponse<List<Interview>>() { StatusCode = 500, Message = error };
                }
                return new GenericResponse<List<Interview>>()
                {
                    StatusCode = 200,
                    Content = result.Results
                };
            }
            catch (Exception ex)
            {

                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return new GenericResponse<List<Interview>>() { StatusCode = 500, Message = message };
            }
        }
    }
}
