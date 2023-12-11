namespace ProjectHub.Data.Abstractions.Entities;

public class ProgrammingLanguage
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public IList<ProjectProgrammingLanguages> ProjectProgrammingLanguages { get; set; } =
        new List<ProjectProgrammingLanguages>();
}