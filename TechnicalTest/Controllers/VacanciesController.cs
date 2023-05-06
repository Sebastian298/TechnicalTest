using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;
using TechnicalTest.Repositories;

namespace TechnicalTest.Controllers
{
    [ApiController,Route("interview/vacancies")]
    [ApiExplorerSettings(GroupName = "Vacancies")]
    [Produces("application/json")]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyRepository _vacancyRepository;

        public VacanciesController(IVacancyRepository vacancyRepository)
        {
           _vacancyRepository = vacancyRepository;
        }

        /// <summary>
        /// Get all vacancies.
        /// </summary>
        /// <response code="200">Returns the list of vacancies</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<List<Vacancy>>), 200)]
        [ProducesResponseType(typeof(GenericResponse<>), 500)]
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
        /// <summary>
        /// Get all active vacancies.
        /// </summary>
        /// <response code="200">Returns the active list of vacancies</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpGet("active")]
        [ProducesResponseType(typeof(GenericResponse<List<Vacancy>>), 200)]
        [ProducesResponseType(typeof(GenericResponse<>), 500)]
        public async Task<IActionResult> GetAllVacanciesActive()
        {
            try
            {
                var result = await _vacancyRepository.GetVacancyActiveAsync();
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }
        /// <summary>
        /// Creates a Vacancy.
        /// </summary>
        /// <param name="vacancy"></param>
        /// <returns>A generic crud response</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Area": "Sistemas",
        ///        "Salary": 21212.221
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<GenericCrud>),201)]
        [ProducesResponseType(typeof(GenericResponse<AttributeResponse>),400)]
        [ProducesResponseType(typeof(GenericResponse<>),500)]
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


        /// <summary>
        /// Update a specific Vacancy.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vacancy"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///        "Area": "Sistemas",
        ///        "Salary": 21212.221,
        ///        "Active":true
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GenericResponse<GenericCrud>), 200)]
        [ProducesResponseType(typeof(GenericResponse<AttributeResponse>), 400)]
        [ProducesResponseType(typeof(GenericResponse<>), 500)]
        public async Task<IActionResult> UpdateVacancy(int id,[FromBody]VacancyUpdate vacancy)
        {
            try
            {
                var result = await _vacancyRepository.UpdateVacancyAsync(id,vacancy);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }

        /// <summary>
        /// Deletes a specific Vacancy.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GenericResponse<GenericCrud>), 200)]
        [ProducesResponseType(typeof(GenericResponse<AttributeResponse>), 400)]
        [ProducesResponseType(typeof(GenericResponse<>), 500)]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            try
            {
                var result = await _vacancyRepository.DeleteVacancyAsync(id);
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
