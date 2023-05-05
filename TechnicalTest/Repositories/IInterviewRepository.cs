using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IInterviewRepository
    {
        Task<GenericResponse<List<Interview>>> GetAllInterviewsAsync();
    }
}
