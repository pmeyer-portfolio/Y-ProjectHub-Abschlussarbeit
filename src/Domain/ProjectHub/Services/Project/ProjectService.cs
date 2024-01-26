namespace ProjectHub.Services.Project;

using ProjectHub.Abstractions.DTOs.Project;
using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Abstractions.IMappers.User;
using ProjectHub.Abstractions.IService.Project;
using ProjectHub.Abstractions.IValidation;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;

public class ProjectService : IProjectService
{
    private readonly IProjectCreateDtoValidator projectCreateDtoValidator;
    private readonly IProjectDtoMapper projectDtoMapper;
    private readonly IProjectMapper projectMapper;
    private readonly IGenericRepository<Project> projectRepository;
    private readonly IUserMapper userMapper;
    private readonly IGenericRepository<User> userRepository;

    public ProjectService(IProjectMapper projectMapper, IGenericRepository<Project> projectRepository,
        IProjectCreateDtoValidator projectCreateDtoValidator, IGenericRepository<User> userRepository,
        IUserMapper userMapper, IProjectDtoMapper projectDtoMapper)
    {
        this.projectMapper = projectMapper;
        this.projectRepository = projectRepository;
        this.projectCreateDtoValidator = projectCreateDtoValidator;
        this.userRepository = userRepository;
        this.userMapper = userMapper;
        this.projectDtoMapper = projectDtoMapper;
    }

    public async Task InsertAsync(ProjectCreateDto dto)
    {
        this.projectCreateDtoValidator.Validate(dto);

        Project project = this.projectMapper.Map(dto);
        await this.EnsureUserExists(dto.User);
        await this.projectRepository.AddAsync(project);
    }

    public async Task<IList<ProjectDto>?> GetAsync()
    {
        IList<Project> projects = await this.projectRepository.GetAllAsync();
        return this.projectDtoMapper.Map(projects);
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        Project? project = await this.projectRepository.GetByIdAsync(id);
        if (project == null)
        {
            return null;
        }

        return this.projectDtoMapper.Map(project);
    }

    public async Task<ProjectDto?> Update(ProjectUpdateDto projectUpdateDto)
    {
        Project? project = await this.projectRepository.GetByIdAsync(projectUpdateDto.Id);
        if (project == null)
        {
            return null;
        }

        project  = this.projectMapper.Map(project, projectUpdateDto);
        await this.projectRepository.UpdateAsync(project);

        project = await this.projectRepository.GetByIdAsync(projectUpdateDto.Id);

        return this.projectDtoMapper.Map(project);
    }
    
    private async Task EnsureUserExists(UserCreateDto userDto)
    {
        User user = this.userMapper.Map(userDto);

        if (!this.userRepository.Exists(user))
        {
            await this.userRepository.AddAsync(user);
        }
    }
}