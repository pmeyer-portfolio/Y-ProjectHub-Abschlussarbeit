namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Services.Base;

public class ProjectService : BaseHttpService, IProjectService
{
    public ProjectService(IProjectHubApiClient apiClient)
        : base(apiClient)
    {
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
            await this.apiClient.ProjectCreatePostAsync(projectCreateDto);
        }
        catch (ApiException<ProblemDetails> e)
        {
            response = this.GetApiExceptionResponse<int>(e);
        }

        return response;
    }
}