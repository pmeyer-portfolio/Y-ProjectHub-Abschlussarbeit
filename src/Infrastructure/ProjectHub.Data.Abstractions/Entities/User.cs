namespace ProjectHub.Data.Abstractions.Entities;

using System.ComponentModel.DataAnnotations;

public class User
{
    public List<Project> CreatedProjects { get; set; } = new();
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Key]
    public required string Email { get; set; }
}