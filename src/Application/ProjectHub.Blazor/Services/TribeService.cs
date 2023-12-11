namespace ProjectHub.Blazor.Services;

using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public class TribeService : BaseHttpService, ITribeService
{
    public TribeService(IProjectHubApiClient apiClient)
        : base(apiClient)
    {
        this.apiClient = apiClient;
    }

    public async Task<Response<IList<TribeViewDto>>> GetAll()
    {
        Response<IList<TribeViewDto>> response;

        try
        {
            IList<TribeViewDto>? data = await this.apiClient.ApiTribeGetAllTribesAsync();
            response = new Response<IList<TribeViewDto>>
            {
                Data = data.ToList(),
                Success = true
            };
        }
        catch (ApiException<ProblemDetails> exception)
        {
            response = this.GetApiExceptionResponse<IList<TribeViewDto>>(exception);
        }

        return response;
    }
}