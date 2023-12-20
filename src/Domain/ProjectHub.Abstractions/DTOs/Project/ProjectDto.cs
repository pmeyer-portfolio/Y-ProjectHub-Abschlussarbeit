namespace ProjectHub.Abstractions.DTOs.Project;

using Newtonsoft.Json;
using ProjectHub.Abstractions.DTOs.User;

public class ProjectDto
{
    public int Id { get; init; }
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public IList<string> ProgrammingLanguages { get; init; } = new List<string>();
    public string? TribeName { get; init; }
    public required string Description { get; init; }
    public required string Title { get; init; }
    public DateTime CreatedAt { get; init; }
    public string? Status { get; init; }
    public required UserDto CreatedBy { get; init; }
}