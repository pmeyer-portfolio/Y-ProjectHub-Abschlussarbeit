namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Mappers;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public class ProjectService : BaseHttpService, IProjectService
{
    private IProjectViewModelMapper ProjectViewModelMapper { get; }
    private IProjectDetailsViewModelMapper ProjectDetailsViewModelMapper { get; }

    public ProjectService(IProjectHubApiClient apiClient, IProjectViewModelMapper projectViewModelMapper, IProjectDetailsViewModelMapper projectDetailsViewModelMapper)
        : base(apiClient)
    {
        this.ProjectViewModelMapper = projectViewModelMapper;
        this.ProjectDetailsViewModelMapper = projectDetailsViewModelMapper;
        this.apiClient = apiClient;
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
            ProjectDto projectDto= await this.apiClient.ApiProjectsGetAsync(id);
            response = new Response<ProjectDetailsViewModel>()
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
}