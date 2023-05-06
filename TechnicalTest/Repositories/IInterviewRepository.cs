using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IInterviewRepository
    {
        Task<GenericResponse<List<Interview>>> GetAllInterviewsAsync();
        Task<GenericResponse<GenericCrud>> CreateInterviewAsync(InterviewCreate interview);
        Task<GenericResponse<GenericCrud>> UpdateInterviewAsync(int id,InterviewUpdate interview);
        Task<GenericResponse<GenericCrud>> DeleteInterviewAsync(int id);
    }
}
