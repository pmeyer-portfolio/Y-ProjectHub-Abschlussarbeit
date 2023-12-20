namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public class TribeService : BaseHttpService, ITribeService
{
    public TribeService(IProjectHubApiClient apiClient)
        : base(apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<Response<IList<TribeDto>>> GetAll()
    {
        Response<IList<TribeDto>> response;

        try
        {
            IList<TribeDto>? tribeDtos = await this.apiClient.ApiTribesGetAsync();
            response = new Response<IList<TribeDto>>
            {
                Data = tribeDtos.ToList(),
                Success = true
            };
        }
        catch (ApiException<ProblemDetails> exception)
        {
            response = this.GetApiExceptionResponse<IList<TribeDto>>(exception);
        }

        return response;
    }
}