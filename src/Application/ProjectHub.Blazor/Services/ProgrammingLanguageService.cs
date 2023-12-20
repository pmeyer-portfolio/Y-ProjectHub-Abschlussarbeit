namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public class ProgrammingLanguageService : BaseHttpService, IProgrammingLanguageService
{
    public ProgrammingLanguageService(IProjectHubApiClient apiClient)
        : base(apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<Response<IList<ProgrammingLanguageDto>>> GetAll()
    {
        Response<IList<ProgrammingLanguageDto>> response;

        try
        {
            IList<ProgrammingLanguageDto>?
                data = await this.apiClient.ApiProgrammingLanguagesGetAsync();
            response = new Response<IList<ProgrammingLanguageDto>>
            {
                Data = data.ToList(),
                Success = true
            };
        }
        catch (ApiException<ProblemDetails> exception)
        {
            response = this.GetApiExceptionResponse<IList<ProgrammingLanguageDto>>(exception);
        }

        return response;
    }
}