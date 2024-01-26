namespace ProjectHub.Blazor.Tests.Mappers.Projects;

using FluentAssertions;
using ProjectHub.Blazor.Mappers.Project;
using ProjectHub.Blazor.Mappers.Project.Interfaces;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;

[TestFixture]
public class ProjectUpdateDtoMapperTests
{
    [SetUp]
    public void Setup()
    {
        this.ProjectUpdateDtoMapper = new ProjectUpdateDtoMapper();
    }

    private IProjectUpdateDtoMapper ProjectUpdateDtoMapper { get; set; } = null!;

    [Test]
    public void Map_Id_IsMappedCorrectly()
    {
        ProjectUpdateModel model = new() { Id = 123 };

        ProjectUpdateDto dto = this.ProjectUpdateDtoMapper.Map(model);

        dto.Id.Should().Be(model.Id);
    }

    [Test]
    public void Map_Status_IsMappedCorrectly()
    {
        ProjectUpdateModel model = new() { Status = "NewStatus" };

        ProjectUpdateDto dto = this.ProjectUpdateDtoMapper.Map(model);

        dto.Status.Should().Be(model.Status);
    }
}