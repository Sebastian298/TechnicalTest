using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;
using TechnicalTest.Repositories;

namespace TechnicalTest.Controllers
{
    [ApiController, Route("interview/interviews")]
    [ApiExplorerSettings(GroupName = "Interviews")]
    [Produces("application/json")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewRepository _interviewRepository;

        public InterviewsController(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }

        /// <summary>
        /// Get all Interviews.
        /// </summary>
        /// <response code="200">Returns the list of interviewa</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<List<Interview>>), 200)]
        [ProducesResponseType(typeof(GenericResponse<>), 500)]
        [HttpGet]
        public async Task<IActionResult> GetAllInterviews()
        {
            try
            {
                var result = await _interviewRepository.GetAllInterviewsAsync();
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }
        /// <summary>
        /// Creates a Interview.
        /// </summary>
        /// <param name="interview"></param>
        /// <returns>A generic crud response</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "VacancyId": 222122,
        ///        "ProspectId": 213322,
        ///        "InterviewDate":"2023-05-06T03:35:01.968Z",
        ///        "Notes":""
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpPost]
        public async Task<IActionResult> CreateInterview(InterviewCreate interview)
        {
            try
            {
                var result = await _interviewRepository.CreateInterviewAsync(interview);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }
        /// <summary>
        /// Update a specific Interview.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="interview"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///        "InterviewDate":"2023-05-06T03:35:01.968Z",
        ///        "Notes":"",
        ///        "Recruited":true
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterview(int id,[FromBody]InterviewUpdate interview)
        {
            try
            {
                var result = await _interviewRepository.UpdateInterviewAsync(id,interview);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }
        /// <summary>
        /// Deletes a specific Interview.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            try
            {
                var result = await _interviewRepository.DeleteInterviewAsync(id);
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
