using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IVacancyRepository
    {
        Task<GenericResponse<List<Vacancy>>> GetVacancysAsync();
        Task<GenericResponse<GenericCrud>> CreateVacancyAsync(VacancyCreate vacancy);
        Task<GenericResponse<GenericCrud>> UpdateVacancyAsync(VacancyUpdate vacancy);
    }
}
