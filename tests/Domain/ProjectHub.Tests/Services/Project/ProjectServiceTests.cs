﻿namespace ProjectHub.Tests.Services.Project;

using FluentAssertions;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Abstractions.IMappers.User;
using ProjectHub.Abstractions.IValidation;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;
using ProjectHub.Services.Project;

[TestFixture]
public class ProjectServiceTests
{
    [SetUp]
    public void Setup()
    {
        this.validator = Substitute.For<IProjectCreateDtoValidator>();
        this.userMapper = Substitute.For<IUserMapper>();
        this.projectMapper = Substitute.For<IProjectMapper>();
        this.projectDtoMapper = Substitute.For<IProjectDtoMapper>();
        this.projectRepository = Substitute.For<IGenericRepository<Project>>();
        this.validator = Substitute.For<IProjectCreateDtoValidator>();
        this.userRepository = Substitute.For<IGenericRepository<User>>();
        this.service =
            new ProjectService(this.projectMapper, this.projectRepository, this.validator, this.userRepository,
                this.userMapper, this.projectDtoMapper);
    }

    private IProjectCreateDtoValidator validator = null!;
    private IGenericRepository<User> userRepository = null!;
    private IUserMapper userMapper = null!;
    private IProjectMapper projectMapper = null!;
    private IGenericRepository<Project> projectRepository = null!;
    private ProjectService service = null!;
    private IProjectDtoMapper projectDtoMapper = null!;


    private static Project GetTestProject()
    {
        return new Project
        {
            Title = "Test Title",
            Description = "Test Description"
        };
    }

    private static ProjectDto GetTestProjectDto()
    {
        return new ProjectDto
        {
            Title = "Test Title",
            Description = "Test Description",
            UserDto = new UserDto
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Email = "test@User.com"
            }
        };
    }

    private static ProjectCreateDto GetProjectCreateDto()
    {
        return new ProjectCreateDto
        {
            Title = "Test Title",
            Description = "Test Description",
            User = new UserCreateDto
            {
                Email = "test@example.com",
                FirstName = "Test",
                LastName = "User"
            }
        };
    }

    [Test]
    public async Task GetAllProjectsAsync_WhenNoProjectsExist_ReturnsEmptyList()
    {
        List<Project> projects = new();
        List<ProjectDto> projectViewDtos = new();

        this.projectRepository.GetAllAsync().Returns(projects);
        this.projectDtoMapper.Map(projects).Returns(projectViewDtos);

        IList<ProjectDto>? result = await this.service.GetAsync();

        result.Should().BeEmpty();
        result.Should().NotBeNull();
    }

    [Test]
    public async Task GetAllProjectsAsync_WhenProjectsExist_ReturnsMappedProjects()
    {
        List<Project> projects = new()
        {
            GetTestProject()
        };
        List<ProjectDto> projectDtos = new()
        {
            GetTestProjectDto()
        };
        this.projectRepository.GetAllAsync().Returns(projects);
        this.projectDtoMapper.Map(projects).Returns(projectDtos);

        IList<ProjectDto>? result = await this.service.GetAsync();

        result.Should().BeEquivalentTo(projectDtos);
    }

    [Test]
    public async Task InsertAsync_ShouldAddProject()
    {
        Project project = GetTestProject();
        ProjectCreateDto projectCreateDto = GetProjectCreateDto();
        this.projectMapper.Map(Arg.Any<ProjectCreateDto>()).Returns(project);

        await this.service.InsertAsync(projectCreateDto);

        await this.projectRepository.Received(1).AddAsync(Arg.Is<Project>(p => p.Title == projectCreateDto.Title));
    }

    [Test]
    public async Task InsertAsync_ShouldMapDtoToProject()
    {
        Project project = GetTestProject();
        ProjectCreateDto projectCreateDto = GetProjectCreateDto();
        this.projectMapper.Map(projectCreateDto).Returns(project);

        await this.service.InsertAsync(projectCreateDto);

        this.projectMapper.Received(1).Map(Arg.Is<ProjectCreateDto>(d => d == projectCreateDto));
    }

    [Test]
    public async Task InsertAsync_ShouldNotAddUserIfExists()
    {
        Project project = GetTestProject();
        ProjectCreateDto projectCreateDto = GetProjectCreateDto();
        this.userRepository.Exists(Arg.Any<User>()).Returns(true);
        this.projectMapper.Map(projectCreateDto).Returns(project);

        await this.service.InsertAsync(projectCreateDto);

        await this.userRepository.DidNotReceive().AddAsync(Arg.Any<User>());
    }

    [Test]
    public async Task InsertAsync_ShouldValidateDto()
    {
        Project project = GetTestProject();
        ProjectCreateDto projectCreateDto = GetProjectCreateDto();
        this.projectMapper.Map(projectCreateDto).Returns(project);

        await this.service.InsertAsync(projectCreateDto);

        this.validator.Received(1).Validate(Arg.Is<ProjectCreateDto>(d => d == projectCreateDto));
    }
}