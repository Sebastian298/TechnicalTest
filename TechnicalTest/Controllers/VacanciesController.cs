using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;
using TechnicalTest.Repositories;

namespace TechnicalTest.Controllers
{
    [ApiController,Route("interview/vacancies")]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyRepository _vacancyRepository;

        public VacanciesController(IVacancyRepository vacancyRepository)
        {
           _vacancyRepository = vacancyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancies()
        {
            try
            {
                var result = await _vacancyRepository.GetVacancysAsync();
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new {StatusCode=500,Message=message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacancy(VacancyCreate vacancy)
        {
            try
            {
                var result = await _vacancyRepository.CreateVacancyAsync(vacancy);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }
    }
}
