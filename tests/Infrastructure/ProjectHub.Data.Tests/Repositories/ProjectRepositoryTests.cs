namespace ProjectHub.Data.Tests.Repositories;

using System.Reflection;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Repositories;

[TestFixture]
public class ProjectRepositoryTests : RepositoryTestBase
{
    [SetUp]
    public void Setup()
    {
        this.repository = new ProjectRepository(this.dbContext);
        this.project = new Project
        {
            Id = 1,
            Title = "Dummy Title",
            Description = "Dummy Description"
        };
    }

    private Project project = null!;
    private ProjectRepository repository = null!;

    [Test]
    public async Task AddAsync_ShouldAddProgrammingLanguages()
    {
        // Act
        await this.repository.AddAsync(this.project);

        // Assert
        Project? result = await this.dbContext.Projects.FindAsync(this.project.Id);
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(this.project);
    }

    [Test]
    public async Task AddAsync_ShouldAddProjectProgrammingLanguageToDbContext()
    {
        //Arrange
        ProgrammingLanguage language = new()
        {
            Name = "C#"
        };

        ProjectProgrammingLanguages references = new()
        {
            Project = this.project,
            ProgrammingLanguage = language,
            ProjectId = this.project.Id,
            ProgrammingLanguageId = language.Id
        };
        this.project.projectProgrammingLanguages = new List<ProjectProgrammingLanguages>
        {
            references
        };

        //Act
        await this.repository.AddAsync(this.project);

        //Assert
        this.dbContext.ProjectProgrammingLanguages.Should().HaveCount(1);
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllProgrammingLanguages()
    {
        //Arrange
        Project firstProject = new()
        {
            Title = "Dummy Title One",
            Description = "Dummy Description One"
        };
        Project secondProject = new()
        {
            Title = "Dummy Title Two",
            Description = "Dummy Title Two"
        };

        await this.repository.AddAsync(firstProject);
        await this.repository.AddAsync(secondProject);

        //Act
        IList<Project> result = await this.dbContext.Projects.ToListAsync();

        //Assert
        result.Should().HaveCount(2);
        result.Should().Contain(new List<Project> { firstProject, secondProject });
    }

    [Test]
    public async Task GetByIdAsync_ReturnsCorrectProgrammingLanguages()
    {
        //Arrange
        await this.repository.AddAsync(this.project);

        // Act
        Project? result = await this.dbContext.Projects.FindAsync(this.project.Id);

        // Assert
        result!.Id.Should().Be(this.project.Id);
    }

    [Test]
    public async Task GetByIdAsync_WhenIdIsNotFound_ReturnsNull()
    {
        // Arrange
        const int requestId = 2;
        await this.repository.AddAsync(this.project);

        // Act
        Project? result = await this.repository.GetByIdAsync(requestId);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public async Task GetProjectsWithAllReferencesAsync_ReturnsAllProjectWithTribeAndProgrammingLanguageReference()
    {
        //Arrange
        const int requestId = 1;
        Tribe tribe = new()
        {
            Id = 1,
            Name = "Tribe My"
        };
        this.project.TribeId = tribe.Id;
        this.project.Tribe = tribe;

        await this.repository.AddAsync(this.project);

        //Act
        Project result = (await this.repository.GetByIdAsync(requestId))!;

        //Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(requestId);
        result.Title.Should().Be(this.project.Title);
        result.Description.Should().Be(this.project.Description);
        result.Tribe.Should().NotBeNull();
        result.TribeId.Should().Be(this.project.TribeId);
        result.Tribe!.Name.Should().Be(tribe.Name);
        result.projectProgrammingLanguages.Should().BeEmpty();
    }

    [Test]
    public async Task
        GetProjectWithAllReferencesByIdAsync_WhenIdIsFound_ReturnsListOfProjectsWithTribeAndReferenceList()
    {
        //Arrange
        Tribe tribe = new()
        {
            Id = 1,
            Name = "Tribe My"
        };

        ProgrammingLanguage language = new()
        {
            Id = 1,
            Name = "C#"
        };

        ProjectProgrammingLanguages references = new()
        {
            Project = this.project,
            ProgrammingLanguage = language,
            ProjectId = this.project.Id,
            ProgrammingLanguageId = language.Id
        };

        this.project.TribeId = tribe.Id;
        this.project.Tribe = tribe;
        this.project.projectProgrammingLanguages = new List<ProjectProgrammingLanguages>
        {
            references
        };

        await this.repository.AddAsync(this.project);

        //Act
        IList<Project> result = await this.repository.GetAllAsync();

        //Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(1);
        result.Single().Id.Should().Be(this.project.Id);
        result.Single().TribeId.Should().Be(tribe.Id);
        result.Single().projectProgrammingLanguages.Should().HaveCount(1);
        result.Single().projectProgrammingLanguages[0].ProgrammingLanguageId.Should().Be(language.Id);
        result.Single().projectProgrammingLanguages[0].ProgrammingLanguage!.Name.Should().Be(language.Name);
        result.Single().projectProgrammingLanguages[0].ProjectId.Should().Be(this.project.Id);
        result.Single().projectProgrammingLanguages[0].Project!.Title.Should().Be(this.project.Title);
    }

    [Test]
    public async Task
        GetProjectWithAllReferencesByIdAsync_WhenIdIsFound_ReturnsProjectWithNoTribeAndEmptyReferenceList()
    {
        //Arrange
        const int requestId = 1;
        await this.repository.AddAsync(this.project);

        //Act
        Project result = (await this.repository.GetByIdAsync(requestId))!;

        //Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(requestId);
        result.Title.Should().Be(this.project.Title);
        result.Description.Should().Be(this.project.Description);
        result.TribeId.Should().BeNull();
        result.projectProgrammingLanguages.Should().BeEmpty();
    }

    [Test]
    public async Task
        GetProjectWithAllReferencesByIdAsync_WhenIdIsFound_ReturnsProjectWithNoTribeWithProgrammingLanguageReference()
    {
        //Arrange
        const int requestId = 1;
        ProgrammingLanguage language = new()
        {
            Name = "C#"
        };

        ProjectProgrammingLanguages references = new()
        {
            Project = this.project,
            ProgrammingLanguage = language,
            ProjectId = this.project.Id,
            ProgrammingLanguageId = language.Id
        };

        this.project.projectProgrammingLanguages = new List<ProjectProgrammingLanguages>
        {
            references
        };

        await this.repository.AddAsync(this.project);

        //Act
        Project result = (await this.repository.GetByIdAsync(requestId))!;

        //Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(requestId);
        result.Title.Should().Be(this.project.Title);
        result.Description.Should().Be(this.project.Description);
        result.TribeId.Should().BeNull();
        result.projectProgrammingLanguages[0].ProgrammingLanguage!.Name.Should().Be(language.Name);
    }

    [Test]
    [TestCase("Updated title")]
    public async Task UpdateAsync_UpdatesEntity(string title)
    {
        // Arrange
        await this.dbContext.AddAsync(this.project);
        await this.dbContext.SaveChangesAsync();

        this.project.Title = title;

        // Act
        await this.repository.UpdateAsync(this.project);

        // Assert
        Project? updatedEntity = await this.dbContext.Projects.FindAsync(this.project.Id);
        updatedEntity!.Title.Should().Be(title);
    }
}