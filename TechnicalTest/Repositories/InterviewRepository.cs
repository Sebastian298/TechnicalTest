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
        public async Task<GenericResponse<GenericCrud>> CreateInterviewAsync(InterviewCreate interview)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:InterviewRepository:Create:Data");
                
                var parameters = new DynamicParameters();
                parameters.Add("vacancyId", interview.VacancyId, DbType.Int64);
                parameters.Add("prospectId", interview.ProspectId, DbType.Int64);
                parameters.Add("interviewDate", interview.InterviewDate, DbType.Date);
                parameters.Add("notes", interview.Notes, DbType.String);
               
                var result = await _dapperService.ExecuteStoredProcedureAsync<GenericCrud>(spData, parameters);

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
        public async Task<GenericResponse<GenericCrud>> UpdateInterviewAsync(int id,InterviewUpdate interview)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:InterviewRepository:Update:Data");

                var parameters = new DynamicParameters();
                parameters.Add("interviewId", id, DbType.Int64);
                parameters.Add("interviewDate", interview.InterviewDate, DbType.Date);
                parameters.Add("notes", interview.Notes, DbType.String);
                parameters.Add("recruited", interview.Recruited, DbType.Boolean);

                var result = await _dapperService.ExecuteStoredProcedureAsync<GenericCrud>(spData, parameters);

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
        public async Task<GenericResponse<GenericCrud>> DeleteInterviewAsync(int id)
        {
            try
            {
                var spData = JsonReader.GetConfigurationStoredProcedure(_configuration, "StoredProceduresSettings:InterviewRepository:Delete:Data");

                var parameters = new DynamicParameters();
                parameters.Add("interviewId", id, DbType.Int64);

                var result = await _dapperService.ExecuteStoredProcedureAsync<GenericCrud>(spData, parameters);

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
    }
}
