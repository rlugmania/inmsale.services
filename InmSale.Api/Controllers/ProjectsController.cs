using InmSale.Dto;
using InmSale.Services;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace InmSale.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectAdministrationService _projectAdministrationService;
    private readonly GeometryFactory _geometryFactory;

    public ProjectsController(IProjectAdministrationService projectAdministrationService, GeometryFactory geometryFactory)
    {
        _projectAdministrationService = projectAdministrationService;
        _geometryFactory = geometryFactory;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterProjectDto dto)
    {
        return Ok(await _projectAdministrationService.RegisterProjectAsync(new Models.Project()
        {
            Name = dto.Name,
            Description = dto.Description,
            Location = _geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude)),
            CreatedAt = DateTime.UtcNow
        }));
    }
}