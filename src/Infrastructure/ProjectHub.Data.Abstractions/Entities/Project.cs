namespace ProjectHub.Data.Abstractions.Entities;

using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
    public IList<ProjectProgrammingLanguages> projectProgrammingLanguages = new List<ProjectProgrammingLanguages>();

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

public abstract class ProjectStatus
{
    public const string New = "Neu";
    public const string Done = "Fertig";
    public const string InProgress = "In Bearbeitung";
}
