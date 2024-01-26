namespace ProjectHub.Blazor.Tests.Mappers.Project
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Components;
    using ProjectHub.Blazor.Constants;
    using ProjectHub.Blazor.Mappers.Project;
    using ProjectHub.Blazor.Models.ProgrammingLanguage;
    using ProjectHub.Blazor.Models.Project;
    using ProjectHub.Blazor.Models.Tribe;
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
            return new ProjectDto
            {
                UserDto = new UserDto(),
                TribeDto = new TribeDto(),
                ProgrammingLanguageDtos = new List<ProgrammingLanguageDto>()
            };
        }

        [Test]
        public void MapCreatedAt_ShouldReturnEqualCreatedAt()
        {
            // Arrange
            DateTime createdAt = new DateTime(2100,1,1);
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
        [TestCase(1,"C#")]
        public void MapProgrammingLanguagesHaveContent_ShouldReturnEqualsContent(int id, string programmingLanguageName)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.ProgrammingLanguageDtos.Add(new ProgrammingLanguageDto
            {
                Id = id,
                Name = programmingLanguageName
            });

            IList<ProgrammingLanguageViewModel> expectedList = new List<ProgrammingLanguageViewModel>
            {
                new ProgrammingLanguageViewModel()
                {
                    Id = id,
                    Name = programmingLanguageName
                }
            };

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.ProgrammingLanguageViewModels.Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void MapProgrammingLanguagesIsEmpty_ShouldReturnNotSpecified()
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.ProgrammingLanguageDtos = new List<ProgrammingLanguageDto>();

            IList<ProgrammingLanguageViewModel> expectedList = new List<ProgrammingLanguageViewModel>
            {
               ProgrammingLanguageViewModel.NotSpecified
            };

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.ProgrammingLanguageViewModels.Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void MapProgrammingLanguagesIsNull_ShouldReturnNotSpecified()
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.ProgrammingLanguageDtos = null;

            IList<ProgrammingLanguageViewModel> expectedList = new List<ProgrammingLanguageViewModel>
            {
                ProgrammingLanguageViewModel.NotSpecified
            };

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.ProgrammingLanguageViewModels.Should().BeEquivalentTo(expectedList);
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
        [TestCase(1,"Tribe My")]
        public void MapTribeDtoIsNotNull_ShouldReturnEqualTribeName(int id, string tribeName)
        {
            // Arrange
            ProjectDto projectDto = CreateProjectDto();
            projectDto.TribeDto = new TribeDto() { Id = id, Name = tribeName };

            // Act
            ProjectDetailsViewModel result = this.projectDetailsViewModelMapper.Map(projectDto);

            // Assert
            result.TribeViewModel.Name.Should().Be(tribeName);
            result.TribeViewModel.Id.Should().Be(id);
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
            result.TribeViewModel.Name.Should().Be(TribeViewModel.NotAssigned.Name);
            result.TribeViewModel.Id.Should().Be(TribeViewModel.NotAssigned.Id);
        }
    }
}