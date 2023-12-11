#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Tests.Services.Project;

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
        this.projectMapper = Substitute.For<IProjectMapper>();
        this.userMapper = Substitute.For<IUserMapper>();
        this.projectRepository = Substitute.For<IGenericRepository<Project>>();
        this.validator = Substitute.For<IProjectCreateDtoValidator>();
        this.userRepository = Substitute.For<IGenericRepository<User>>();
        this.service =
            new ProjectService(this.projectMapper, this.projectRepository, this.validator, this.userRepository,
                this.userMapper);

        this.project = new Project
        {
            Title = "Test Title",
            Description = "Test Description"
        };

        this.createDto = new ProjectCreateDto
        {
            Title = this.project.Title,
            Description = this.project.Description,
            User = new UserCreateDto
            {
                Email = "test@example.com",
                FirstName = "Test",
                LastName = "Users"
            }
        };
    }

    private ProjectCreateDto createDto;
    private IProjectMapper projectMapper;
    private Project project;
    private IGenericRepository<Project> projectRepository;
    private ProjectService service;
    private IProjectCreateDtoValidator validator;
    private IGenericRepository<User> userRepository;
    private IUserMapper userMapper;

    [Test]
    public async Task InsertAsync_ShouldAddProject()
    {
        this.projectMapper.Map(Arg.Any<ProjectCreateDto>()).Returns(this.project);

        await this.service.InsertAsync(this.createDto);

        await this.projectRepository.Received(1).AddAsync(Arg.Is<Project>(p => p.Title == this.createDto.Title));
    }

    [Test]
    public async Task InsertAsync_ShouldMapDtoToProject()
    {
        this.projectMapper.Map(this.createDto).Returns(this.project);

        await this.service.InsertAsync(this.createDto);

        this.projectMapper.Received(1).Map(Arg.Is<ProjectCreateDto>(d => d == this.createDto));
    }

    [Test]
    public async Task InsertAsync_ShouldNotAddUserIfExists()
    {
        this.userRepository.Exists(Arg.Any<User>()).Returns(true);
        this.projectMapper.Map(this.createDto).Returns(this.project);

        await this.service.InsertAsync(this.createDto);

        await this.userRepository.DidNotReceive().AddAsync(Arg.Any<User>());
    }

    [Test]
    public async Task InsertAsync_ShouldValidateDto()
    {
        this.projectMapper.Map(this.createDto).Returns(this.project);

        await this.service.InsertAsync(this.createDto);

        this.validator.Received(1).Validate(Arg.Is<ProjectCreateDto>(d => d == this.createDto));
    }
}