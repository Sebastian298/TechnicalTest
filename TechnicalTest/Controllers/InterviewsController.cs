using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helpers;
using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Repositories;

namespace TechnicalTest.Controllers
{
    [ApiController, Route("interview/interviews")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewRepository _interviewRepository;

        public InterviewsController(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }
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

        [HttpPut]
        public async Task<IActionResult> UpdateInterview(InterviewUpdate interview)
        {
            try
            {
                var result = await _interviewRepository.UpdateInterviewAsync(interview);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var message = MessageErrorBuilder.GenerateError(ex.Message);
                return StatusCode(500, new { StatusCode = 500, Message = message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInterview(int interviewId)
        {
            try
            {
                var result = await _interviewRepository.DeleteInterviewAsync(interviewId);
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
