namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public class ProgrammingLanguageService : BaseHttpService, IProgrammingLanguageService
{
    public ProgrammingLanguageService(IProjectHubApiClient apiClient)
        : base(apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<Response<IList<ProgrammingLanguageViewDto>>> GetAll()
    {
        Response<IList<ProgrammingLanguageViewDto>> response;

        try
        {
            IList<ProgrammingLanguageViewDto>?
                data = await this.apiClient.ApiProgrammingLanguagesGetAllLanguagesAsync();
            response = new Response<IList<ProgrammingLanguageViewDto>>
            {
                Data    = data.ToList(),
                Success = true
            };
        }
        catch (ApiException<ProblemDetails> exception)
        {
            response = this.GetApiExceptionResponse<IList<ProgrammingLanguageViewDto>>(exception);
        }

        return response;
    }
}