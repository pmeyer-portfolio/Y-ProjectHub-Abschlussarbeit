namespace ProjectHub.Abstractions.IValidation;

using ProjectHub.Abstractions.DTOs.Project;

public interface IProjectCreateDtoValidator
{
    void Validate(ProjectCreateDto dto);
}