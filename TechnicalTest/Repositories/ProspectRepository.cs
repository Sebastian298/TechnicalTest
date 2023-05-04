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
        public async Task<GenericResponse<GenericCrud>> CreateProspectAsync(ProspectCreate prospect)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:ProspectRepository:Create:Data");
                var parameters = new DynamicParameters();
                parameters.Add("name", prospect.Name, DbType.String);
                parameters.Add("email", prospect.Email, DbType.String);
                parameters.Add("registeredDate", DateTime.Now, DbType.DateTime);
                var result = await _service.ExecuteStoredProcedureAsync<GenericCrud>(spData, parameters);
                if (result.HasError)
                {
                    var error = MessageErrorBuilder.GenerateError(result.Message);
                    return new GenericResponse<GenericCrud>()
                    {
                        StatusCode = 500,
                        Message = error
                    };
                }
                return new GenericResponse<GenericCrud>()
                {
                    StatusCode = 201,
                    Content = result.Results
                };
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return new GenericResponse<GenericCrud>() { StatusCode = 500, Message = message };
            }
        }
        public async Task<GenericResponse<GenericCrud>> UpdateProspectAsync(ProspectUpdate prospect)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:ProspectRepository:Update:Data");
                var parameters = new DynamicParameters();
                parameters.Add("prospectId", prospect.Id, DbType.Int64);
                parameters.Add("name", prospect.Name, DbType.String);
                parameters.Add("email", prospect.Email, DbType.String);
                var result = await _service.ExecuteStoredProcedureAsync<GenericCrud>(spData, parameters);
                if (result.HasError)
                {
                    var error = MessageErrorBuilder.GenerateError(result.Message);
                    return new GenericResponse<GenericCrud>()
                    {
                        StatusCode = 500,
                        Message = error
                    };
                }
                return new GenericResponse<GenericCrud>()
                {
                    StatusCode = 200,
                    Content = result.Results
                };
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return new GenericResponse<GenericCrud>() { StatusCode = 500, Message = message };
            }
        }
    }
}
