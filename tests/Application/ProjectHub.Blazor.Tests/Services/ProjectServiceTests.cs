namespace ProjectHub.Blazor.Tests.Services;

using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Blazor.Mappers;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services;
using ProjectHub.Blazor.Services.Base;

[TestFixture]
public class ProjectServiceTests
{
    [SetUp]
    public void SetUp()
    {
        this.projectHubApiClient = Substitute.For<IProjectHubApiClient>();
        this.projectViewModelMapper = Substitute.For<IProjectViewModelMapper>();
        this.projectService = new ProjectService(this.projectHubApiClient, this.projectViewModelMapper);
    }

    private ProjectService projectService = null!;
    private IProjectHubApiClient projectHubApiClient = null!;
    private IProjectViewModelMapper projectViewModelMapper = null!;

    [Test]
    public async Task Create_WhenApiExceptionOccurs_ReturnsErrorResponse()
    {
        // Arrange
        ApiException<ProblemDetails> apiException = new(
            "Error message",
            500,
            "Error details",
            new Dictionary<string,
                IEnumerable<string>>(),
            new ProblemDetails(),
            new Exception());

        ProjectCreateDto projectCreateDto = new();
        this.projectHubApiClient.ApiProjectsPostAsync(Arg.Any<ProjectCreateDto>())
            .Throws(apiException);

        // Act
        Response<int> result = await this.projectService.Create(projectCreateDto);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
    }

    [Test]
    public async Task Create_WhenCalled_ReturnsSuccess()
    {
        // Arrange
        ProjectCreateDto projectCreateDto = new ProjectCreateDto();

        // Act
        Response<int> result = await this.projectService.Create(projectCreateDto);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
    }

    [Test]
    public async Task GetAll_WhenApiExceptionOccurs_ReturnsErrorResponse()
    {
        // Arrange
        ApiException<ProblemDetails> apiException = new(
            "Error message",
            400,
            "Error details",
            new Dictionary<string,
                IEnumerable<string>>(),
            new ProblemDetails(),
            new Exception());

        this.projectHubApiClient.ApiProjectsGetAsync()
            .Throws(apiException);

        // Act
        Response<IList<ProjectViewModel>> result = await this.projectService.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
    }

    [Test]
    public async Task GetAll_WhenCalled_ReturnsSuccessWithData()
    {
        // Arrange
        List<ProjectDto> projectDtos = new();
        List<ProjectViewModel> projectViewModels = new();
        this.projectHubApiClient.ApiProjectsGetAsync().Returns(projectDtos);
        this.projectViewModelMapper.Map(Arg.Any<IList<ProjectDto>>()).Returns(projectViewModels);

        // Act
        Response<IList<ProjectViewModel>> result = await this.projectService.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(projectViewModels);
    }
}