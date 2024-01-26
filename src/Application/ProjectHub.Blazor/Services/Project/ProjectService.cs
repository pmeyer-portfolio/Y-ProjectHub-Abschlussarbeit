namespace ProjectHub.Blazor.Services.Project;

using ProjectHub.Blazor.Mappers.Project.Interfaces;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Project.Interfaces;

public class ProjectService : BaseHttpService, IProjectService
{
    private readonly IProjectUpdateDtoMapper projectUpdateDtoMapper;
    private IProjectViewModelMapper ProjectViewModelMapper { get; }
    private IProjectDetailsViewModelMapper ProjectDetailsViewModelMapper { get; }

    public ProjectService(
        IProjectHubApiClient apiClient,
        IProjectViewModelMapper projectViewModelMapper,
        IProjectDetailsViewModelMapper projectDetailsViewModelMapper,
        IProjectUpdateDtoMapper projectUpdateDtoMapper
    )
        : base(apiClient)
    {
        this.ProjectViewModelMapper = projectViewModelMapper;
        this.ProjectDetailsViewModelMapper = projectDetailsViewModelMapper;
        this.projectUpdateDtoMapper = projectUpdateDtoMapper;
        this.apiClient = apiClient;
    }

    public async Task<ProjectDetailsViewModel> LoadProjectDetails(int projectId)
    {
        Response<ProjectDetailsViewModel> response = await this.GetById(projectId);
        return response.Data ?? new ProjectDetailsViewModel();
    }

    public async Task<Response<int>> Create(ProjectCreateDto projectCreateDto)
    {
        Response<int> response = new()
        {
            Success = true
        };

        try
        {
            await this.apiClient.ApiProjectsPostAsync(projectCreateDto);
        }
        catch (ApiException<ProblemDetails> e)
        {
            response = this.GetApiExceptionResponse<int>(e);
        }

        return response;
    }

    public async Task<Response<IList<ProjectViewModel>>> GetAll()
    {
        Response<IList<ProjectViewModel>> response;

        try
        {
            IList<ProjectDto> projectViewDtos = await this.apiClient.ApiProjectsGetAsync();
            response = new Response<IList<ProjectViewModel>>
            {
                Success = true,
                Data = this.ProjectViewModelMapper.Map(projectViewDtos)
            };
        }
        catch (ApiException<ProblemDetails> e)
        {
            response = this.GetApiExceptionResponse<IList<ProjectViewModel>>(e);
        }

        return response;
    }

    public async Task<Response<ProjectDetailsViewModel>> GetById(int id)
    {
        Response<ProjectDetailsViewModel> response;

        try
        {
            ProjectDto projectDto = await this.apiClient.ApiProjectsGetAsync(id);
            response = new Response<ProjectDetailsViewModel>
            {
                Success = true,
                Data = this.ProjectDetailsViewModelMapper.Map(projectDto)
            };
        }
        catch (ApiException<ProblemDetails> e)
        {
            response = this.GetApiExceptionResponse<ProjectDetailsViewModel>(e);
        }

        return response;
    }

    public async Task<Response<ProjectUpdateDto>> Update(ProjectUpdateModel updateModel)
    {
        Response<ProjectUpdateDto> response;

        ProjectUpdateDto projectUpdateDto = this.projectUpdateDtoMapper.Map(updateModel);
        try
        {
            await this.apiClient.ApiProjectsPutAsync(projectUpdateDto);
            response = new Response<ProjectUpdateDto>
            {
                Success = true,
            };
        }
        catch (ApiException<ProblemDetails> e)
        {
            response = this.GetApiExceptionResponse<ProjectUpdateDto>(e);
        }
        catch (HttpRequestException e)
        {
            response = new Response<ProjectUpdateDto>()
            {
                DetailMessage = "Api nicht erreichbar."
            };
        }
        return response;
    }
}