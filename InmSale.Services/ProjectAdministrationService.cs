using InmSale.Models;
using InmSale.Models.Responses;
using InmSale.Repositories;

namespace InmSale.Services;

public class ProjectAdministrationService : IProjectAdministrationService
{
    private readonly IProjectsRepository _projectsRepository;

    public ProjectAdministrationService(IProjectsRepository projectsRepository)
    {
        _projectsRepository = projectsRepository;
    }

    public async Task<ProjectAdministrativeActionResponse> RegisterProjectAsync(Project project)
    {
        if (await _projectsRepository.CountAsync(p => p.Name == project.Name) > 0)
            throw new Exception("A project with the same name is already registered");
        await _projectsRepository.RegisterAsync(project);

        return new ProjectAdministrativeActionResponse(ProjectAdministrativeActionCodes.ProjectCreated, $"Project {project.Name} Registered");
    }
}