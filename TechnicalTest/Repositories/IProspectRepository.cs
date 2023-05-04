using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IProspectRepository
    {
        Task<GenericResponse<List<Prospect>>> GetAllProspectsAsync();
    }
}
