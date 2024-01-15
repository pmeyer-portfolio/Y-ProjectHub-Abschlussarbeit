namespace ProjectHub.Blazor.Tests.Mappers
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Components;
    using ProjectHub.Blazor.Constants;
    using ProjectHub.Blazor.Mappers;
    using ProjectHub.Blazor.Models;
    using ProjectHub.Blazor.Services.Base;

    [TestFixture]
    public class ProjectDetailsViewModelMapperTests
    {
        [SetUp]
        public void Setup()
        {
            this.projectDetailsViewModelMapper = new ProjectDetailsViewModelMapper();
        }

        private ProjectDetailsViewModelMapper projectDetailsViewModelMapper = null!;

        private static ProjectDto CreateProjectDto()
        {
            return new()
            {
                UserDto = new UserDto(),
                TribeDto = new TribeDto(),
                ProgrammingLanguageDtos = new List<ProgrammingLanguageDto>()
            };
        }

        [Test]
        [TestCase("C#")]
        public void MapProgrammingLanguagesHaveContent_ShouldReturnEqualsContent(string programmingLanguageName)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.ProgrammingLanguageDtos.Add(new ProgrammingLanguageDto()
            {
                Id = 1,
                Name = programmingLanguageName
            });

            IList<string> expectedList = new List<string>
            {
                programmingLanguageName
            };

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.ProgrammingLanguages.Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void MapProgrammingLanguagesIsEmpty_ShouldReturnNotSpecified()
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.ProgrammingLanguageDtos = new List<ProgrammingLanguageDto>();

            IList<string> expectedList = new List<string>
            {
                PlaceHolder.NotSpecified
            };

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.ProgrammingLanguages.Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void MapProgrammingLanguagesIsNull_ShouldReturnNotSpecified()
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.ProgrammingLanguageDtos = null;

            IList<string> expectedList = new List<string>
            {
                PlaceHolder.NotSpecified
            };

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.ProgrammingLanguages.Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void MapCreatedAt_ShouldReturnEqualCreatedAt()
        {
            // Arrange
            DateTime createdAt = DateTime.MinValue;
            ProjectDto projectDto = CreateProjectDto();
            projectDto.CreatedAt = createdAt;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.CreatedAt.Should().Be(createdAt);
        }

        [Test]
        public void MapCreatedBy_ShouldReturnEqualCreatedBy()
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.CreatedBy.Should().NotBeNull();
        }

        [Test]
        [TestCase("first name", "last name")]
        public void MapCreatedByFirstName_ShouldReturnEqualCreatedByFirstName(string firstName, string lastName)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.UserDto.FirstName = firstName;
            projectDto.UserDto.LastName = lastName;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.CreatedBy.Should().Be(firstName + " " + lastName);
        }

        [Test]
        [TestCase("Project-description")]
        public void MapDescription_ShouldReturnEqualDescription(string description)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.Description = description;
            MarkupString descriptionAsMarkup = new(description);

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.Description.Should().Be(descriptionAsMarkup);
        }

        [Test]
        [TestCase("test@example.com")]
        public void MapEmail_ShouldReturnEqualEmail(string email)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.UserDto.Email = email;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.CreatorEmail.Should().Be(email);
        }

        [Test]
        [TestCase(3)]
        public void MapId_ShouldReturnEqualId(int id)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.Id = id;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.Id.Should().Be(id);
        }

        [Test]
        [TestCase("Project status")]
        public void MapStatus_ShouldReturnEqualStatus(string status)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.Status = status;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.Status.Should().NotBeNull(status);
        }

        [Test]
        [TestCase("Project-title")]
        public void MapTitle_ShouldReturnEqualTitle(string title)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.Title = title;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.Title.Should().Be(title);
        }

        [Test]
        [TestCase("Tribe My")]
        public void MapTribeDtoIsNotNull_ShouldReturnEqualTribeName(string tribeName)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.TribeDto.Name = tribeName;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.TribeName.Should().Be(tribeName);
        }

        [Test]
        public void MapTribeDtoIsNull_ShouldReturn_NotAssigned()
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.TribeDto = null;

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.TribeName.Should().Be(PlaceHolder.NotAssigned);
        }
    }
}