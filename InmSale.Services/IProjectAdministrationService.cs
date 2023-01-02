using InmSale.Models;
using InmSale.Models.Responses;

namespace InmSale.Services
{
    public interface IProjectAdministrationService
    {
        Task<ProjectAdministrativeActionResponse> RegisterProjectAsync(Project project);
    }
}