using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;
using TechnicalTest.Repositories;

namespace TechnicalTest.Controllers
{
    [ApiController, Route("interview/prospects")]
    [ApiExplorerSettings(GroupName = "Prospects")]
    [Produces("application/json")]
    public class ProspectsController : ControllerBase
    {
        private readonly IProspectRepository _prospectRepository;

        public ProspectsController(IProspectRepository prospectRepository)
        {
            _prospectRepository = prospectRepository;
        }

        /// <summary>
        /// Get all Prospects.
        /// </summary>
        /// <response code="200">Returns the list of prospects</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<List<Prospect>>), 200)]
        [ProducesResponseType(typeof(GenericResponse<>), 500)]
        public async Task<IActionResult> GetAllProspects()
        {
            try
            {
                var result = await _prospectRepository.GetAllProspectsAsync();
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }
        /// <summary>
        /// Creates a Prospect.
        /// </summary>
        /// <param name="prospect"></param>
        /// <returns>A generic crud response</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Name": "Prueba",
        ///        "Email": "test@outlook.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<GenericCrud>), 201)]
        [ProducesResponseType(typeof(GenericResponse<AttributeResponse>), 400)]
        [ProducesResponseType(typeof(GenericResponse<>), 500)]
        public async Task<IActionResult> CreateProspect(ProspectCreate prospect)
        {
            try
            {
                var result = await _prospectRepository.CreateProspectAsync(prospect);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }

        /// <summary>
        /// Update a specific Prospect.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prospect"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///        "Name": "Prueba",
        ///        "Email": "test@outlook.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the generic crud response</response>
        /// <response code="400">If the object is null or the format of the values isn't valide</response>
        /// <response code="500">If a error occurred in the api logic</response>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProspect(int id,[FromBody] ProspectUpdate prospect)
        {
            try
            {
                var result = await _prospectRepository.UpdateProspectAsync(id,prospect);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }
        /// <summary>
        /// Deletes a specific Prospect.
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
        public async Task<IActionResult> DeleteProspect(int id)
        {
            try
            {
                var result = await _prospectRepository.DeleteProspectAsync(id);
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
