using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IVacancyRepository
    {
        Task<GenericResponse<List<Vacancy>>> GetVacancysAsync();
    }
}
