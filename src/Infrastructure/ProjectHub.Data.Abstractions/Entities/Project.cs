namespace ProjectHub.Data.Abstractions.Entities;

using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
    public IList<ProjectProgrammingLanguages> projectProgrammingLanguages = new List<ProjectProgrammingLanguages>();

    public static readonly Project NotFound = new()
    {
        Id = -1,
        Title = "Project not found Title",
        Description = "Project not found Description"
    };

    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    [ForeignKey("TribeId")]
    public Tribe? Tribe { get; set; }

    public int? TribeId { get; set; }
    public DateTime Created { get; set; }

    public string Status { get; set; } = ProjectStatus.New;

    [ForeignKey("UserUuid")]
    public User? User { get; set; }

    public string? UserUuid { get; set; }
}

public static class ProjectStatus
{
    public const string New = "New";
}