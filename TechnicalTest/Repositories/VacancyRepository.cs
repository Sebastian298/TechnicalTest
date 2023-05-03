
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
                var result = await _service.ExecuteStoredProcedureAsync<Vacancy>(spData, null, true);
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
    }
}
