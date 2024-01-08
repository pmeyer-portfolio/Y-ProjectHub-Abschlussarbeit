namespace ProjectHub.Abstractions.DTOs.Project;

using Newtonsoft.Json;
using ProjectHub.Abstractions.DTOs.ProgrammingLanguage;
using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Abstractions.DTOs.User;

public class ProjectDto
{
    public int Id { get; init; }
    public IList<ProgrammingLanguageDto> ProgrammingLanguageDtos { get; init; } = new List<ProgrammingLanguageDto>();
    public TribeDto? TribeDto { get; set; }
    public required string Description { get; init; }
    public required string Title { get; init; }
    public DateTime CreatedAt { get; init; }
    public string? Status { get; init; }
    public required UserDto UserDto { get; init; }
}