namespace ProjectHub.Abstractions.DTOs.Project;

using ProjectHub.Abstractions.DTOs.User;

public record ProjectCreateDto
{
    public IList<int>    Languages   { get; set; } = new List<int>();
    public string?       Title       { get; init; }
    public string?       Description { get; init; }
    public int?          TribeId     { get; init; }
    public DateTime      Created     { get; init; }
    public UserCreateDto User        { get; set; }
}