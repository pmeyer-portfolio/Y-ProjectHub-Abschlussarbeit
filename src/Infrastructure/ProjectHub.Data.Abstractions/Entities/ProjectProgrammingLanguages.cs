namespace ProjectHub.Data.Abstractions.Entities;

public class ProjectProgrammingLanguages
{
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public ProgrammingLanguage? ProgrammingLanguage { get; set; }
}