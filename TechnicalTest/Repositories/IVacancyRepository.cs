﻿using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IVacancyRepository
    {
        Task<GenericResponse<List<Vacancy>>> GetVacancysAsync();
        Task<GenericResponse<List<VacancyActive>>> GetVacancyActiveAsync();
        Task<GenericResponse<GenericCrud>> CreateVacancyAsync(VacancyCreate vacancy);
        Task<GenericResponse<GenericCrud>> UpdateVacancyAsync(int id,VacancyUpdate vacancy);
        Task<GenericResponse<GenericCrud>> DeleteVacancyAsync(int id);
    }
}
