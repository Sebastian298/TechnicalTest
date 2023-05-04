using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IProspectRepository
    {
        Task<GenericResponse<List<Prospect>>> GetAllProspectsAsync();
        Task<GenericResponse<GenericCrud>> CreateProspectAsync(ProspectCreate prospect);
    }
}
