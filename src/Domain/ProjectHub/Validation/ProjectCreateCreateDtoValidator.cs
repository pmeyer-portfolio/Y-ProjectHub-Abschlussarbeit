namespace ProjectHub.Validation;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.Exceptions.ValidationEx;
using ProjectHub.Abstractions.IValidation;

public class ProjectCreateCreateDtoValidator : IProjectCreateDtoValidator
{
    public void Validate(ProjectCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new ProjectTitleIsNullOrWhiteSpaceException(ProjectCreateValidationExceptionMessages.TitleRequired);
        }

        if (string.IsNullOrWhiteSpace(dto.Description))
        {
            throw new ProjectDescriptionIsNullOrWhiteSpaceException(ProjectCreateValidationExceptionMessages
                                                                        .DescriptionRequired);
        }
    }
}