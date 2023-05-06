﻿using TechnicalTest.Models.BusinessLogic;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Repositories
{
    public interface IProspectRepository
    {
        Task<GenericResponse<List<Prospect>>> GetAllProspectsAsync();
        Task<GenericResponse<GenericCrud>> CreateProspectAsync(ProspectCreate prospect);
        Task<GenericResponse<GenericCrud>> UpdateProspectAsync(int id,ProspectUpdate prospect);
        Task<GenericResponse<GenericCrud>> DeleteProspectAsync(int id);
    }
}
