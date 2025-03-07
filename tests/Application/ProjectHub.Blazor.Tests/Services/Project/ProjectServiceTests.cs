﻿namespace ProjectHub.Blazor.Tests.Services.Project;

using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Blazor.Mappers.Project.Interfaces;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Project;

[TestFixture]
public class ProjectServiceTests
{
    [SetUp]
    public void SetUp()
    {
        this.projectHubApiClient = Substitute.For<IProjectHubApiClient>();
        this.projectViewModelMapper = Substitute.For<IProjectViewModelMapper>();
        this.projectDetailsViewModelMapper = Substitute.For<IProjectDetailsViewModelMapper>();
        this.projectService = new ProjectService(this.projectHubApiClient, this.projectViewModelMapper,
            this.projectDetailsViewModelMapper, this.projectUpdateDtoMapper);
    }

    private ProjectService projectService = null!;
    private IProjectHubApiClient projectHubApiClient = null!;
    private IProjectViewModelMapper projectViewModelMapper = null!;
    private IProjectDetailsViewModelMapper projectDetailsViewModelMapper = null!;
    private readonly IProjectUpdateDtoMapper projectUpdateDtoMapper = null!;

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

    [Test]
    public async Task GetById_WhenApiExceptionOccurs_ReturnsErrorResponse()
    {
        // Arrange
        int projectId = 1;
        ApiException<ProblemDetails> apiException = new ApiException<ProblemDetails>("Error message", 404,
            "Error details", new Dictionary<string, IEnumerable<string>>(), new ProblemDetails(), new Exception());
        this.projectHubApiClient.ApiProjectsGetAsync(projectId).Throws(apiException);

        // Act
        Response<ProjectDetailsViewModel> result = await this.projectService.GetById(projectId);

        // Assert
        result.Success.Should().BeFalse();
        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
    }

    [Test]
    public async Task GetById_WhenCalled_ReturnsSuccessWithData()
    {
        // Arrange
        const int projectId = 1;
        ProjectDto projectDto = new();
        ProjectDetailsViewModel projectDetailsViewModel = new ProjectDetailsViewModel
        {
            CreatorEmail = "test@mail.com"
        };
        this.projectHubApiClient.ApiProjectsGetAsync(projectId).Returns(projectDto);
        this.projectDetailsViewModelMapper.Map(projectDto).Returns(projectDetailsViewModel);

        // Act
        Response<ProjectDetailsViewModel> result = await this.projectService.GetById(projectId);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(projectDetailsViewModel);
    }

    [Test]
    public async Task LoadProjectDetails_WhenProjectDoesNotExist_ShouldReturnEmptyProjectDetailsViewModel()
    {
        const int projectId = 1;
        this.projectHubApiClient.ApiProjectsGetAsync(projectId)
            .Returns(Task.FromResult<ProjectDto>(null));

        ProjectDetailsViewModel result = await this.projectService.LoadProjectDetails(projectId);

        result.Should().BeEquivalentTo(new ProjectDetailsViewModel());
    }

    [Test]
    public async Task LoadProjectDetails_WhenProjectExists_ShouldReturnProjectDetailsViewModel()
    {
        const int projectId = 1;
        ProjectDetailsViewModel expectedProjectDetails = new()
        {
            Id = projectId,
        };

        this.projectHubApiClient.ApiProjectsGetAsync(projectId)
            .Returns(Task.FromResult(new ProjectDto
            {
                Id = expectedProjectDetails.Id,
            }));

        this.projectDetailsViewModelMapper.Map(Arg.Any<ProjectDto>())
            .Returns(expectedProjectDetails);

        ProjectDetailsViewModel result = await this.projectService.LoadProjectDetails(projectId);

        result.Should().BeEquivalentTo(expectedProjectDetails);
        result.Id.Should().Be(projectId);
    }
}