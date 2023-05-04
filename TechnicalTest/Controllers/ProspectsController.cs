using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Repositories;

namespace TechnicalTest.Controllers
{
    [ApiController, Route("interview/prospects")]
    public class ProspectsController : ControllerBase
    {
        private readonly IProspectRepository _prospectRepository;

        public ProspectsController(IProspectRepository prospectRepository)
        {
            _prospectRepository = prospectRepository;
        }

        [HttpGet]
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

        [HttpPost]
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
    }
}
