namespace ProjectHub.Tests.Validation;

using FluentAssertions;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.Exceptions.ValidationEx;
using ProjectHub.Validation;

public class ProjectCreateCreateDtoValidatorTests
{
    [TestCase("")]
    [TestCase("        ")]
    public void Validate_ShouldThrowException_WhenTitleIsNullOrWhiteSpace(string title)
    {
        //Arrange
        ProjectCreateDto dto = new()
        {
            Title = title,
            Description = "Description"
        };

        ProjectCreateCreateDtoValidator validator = new();

        //Act
        Action action = () => validator.Validate(dto);

        //Assert
        action.Should().Throw<ProjectTitleIsNullOrWhiteSpaceException>();
    }

    [TestCase("")]
    [TestCase("           ")]
    public void Validate_ShouldThrowException_WhenDescriptionIsNullOrWhiteSpace(string description)
    {
        //Arrange
        ProjectCreateDto dto = new()
        {
            Title = "Title",
            Description = description
        };

        ProjectCreateCreateDtoValidator validator = new();

        //Act
        Action action = delegate { validator.Validate(dto); };

        //Assert
        action.Should().Throw<ProjectDescriptionIsNullOrWhiteSpaceException>();
    }

    [Test]
    public void Validate_ShouldThrowNoException_WhenTitleAndDescriptionIsValid()
    {
        //Arrange
        ProjectCreateDto dto = new()
        {
            Title = "This is a valid Projecttitle",
            Description = "This is a valid Description"
        };

        ProjectCreateCreateDtoValidator validator = new();
        //Act
        Action action = delegate { validator.Validate(dto); };

        //Assert
        action.Should().NotThrow();
    }
}