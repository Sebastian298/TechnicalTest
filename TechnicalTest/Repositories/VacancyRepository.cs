
using Dapper;
using System.Data;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;
using TechnicalTest.Services;

namespace TechnicalTest.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly IDapperService _service;
        private readonly IConfiguration _configuration;

        public VacancyRepository(IDapperService service,IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        public async Task<GenericResponse<List<Vacancy>>> GetVacancysAsync()
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:VacancyRepository:GetAll:Data");
                var parameters = new DynamicParameters();
                parameters.Add("Option", 1, DbType.Int64);
                var result = await _service.ExecuteStoredProcedureAsync<Vacancy>(spData, parameters, true);
                if (result.HasError)
                {
                    var error = MessageErrorBuilder.GenerateError(result.Message);
                    return new GenericResponse<List<Vacancy>>() { StatusCode = 500, Message = error };
                }
                return new GenericResponse<List<Vacancy>>()
                {
                    StatusCode = 200,
                    Content = result.Results
                };

            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return new GenericResponse<List<Vacancy>>() { StatusCode = 500,Message = message};
            }
        }

        public async Task<GenericResponse<List<VacancyActive>>> GetVacancyActiveAsync()
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:VacancyRepository:GetAll:Data");
                var parameters = new DynamicParameters();
                parameters.Add("Option", 2, DbType.Int64);
                var result = await _service.ExecuteStoredProcedureAsync<VacancyActive>(spData, parameters, true);
                if (result.HasError)
                {
                    var error = MessageErrorBuilder.GenerateError(result.Message);
                    return new GenericResponse<List<VacancyActive>>() { StatusCode = 500, Message = error };
                }
                return new GenericResponse<List<VacancyActive>>()
                {
                    StatusCode = 200,
                    Content = result.Results
                };

            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return new GenericResponse<List<VacancyActive>>() { StatusCode = 500, Message = message };
            }
        }

        public async Task<GenericResponse<GenericCrud>> CreateVacancyAsync(VacancyCreate vacancy)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:VacancyRepository:Create:Data");
                var parameters = new DynamicParameters();
                parameters.Add("area", vacancy.Area, DbType.String);
                parameters.Add("salary", vacancy.Salary, DbType.Decimal);
                var result =  await _service.ExecuteStoredProcedureAsync<GenericCrud>(spData, parameters);
                if (result.HasError)
                {
                    var error = MessageErrorBuilder.GenerateError(result.Message);
                    return new GenericResponse<GenericCrud>()
                    {
                        StatusCode=500,
                        Message = error
                    };
                }
                return new GenericResponse<GenericCrud>()
                {
                    StatusCode=201,
                    Content = result.Results
                };
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return new GenericResponse<GenericCrud>() { StatusCode = 500, Message = message };
            }
        }

        public async Task<GenericResponse<GenericCrud>> UpdateVacancyAsync(VacancyUpdate vacancy)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:VacancyRepository:Update:Data");
                var parameters = new DynamicParameters();
                parameters.Add("vacancyId", vacancy.Id, DbType.Int64);
                parameters.Add("area", vacancy.Area, DbType.String);
                parameters.Add("salary", vacancy.Salary, DbType.Decimal);
                parameters.Add("active", vacancy.Active, DbType.Boolean);
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

        public async Task<GenericResponse<GenericCrud>> DeleteVacancyAsync(VacancyDelete vacancy)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:VacancyRepository:Delete:Data");
                var parameters = new DynamicParameters();
                parameters.Add("vacancyId", vacancy.Id, DbType.Int64);
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