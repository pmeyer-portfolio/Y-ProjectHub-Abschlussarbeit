namespace ProjectHub.Blazor.Services.Tribe;

using ProjectHub.Blazor.Mappers.Tribe;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;

public class TribeService : BaseHttpService, ITribeService
{
    private readonly ITribeViewModelMapper tribeViewModelMapper;

    public TribeService(IProjectHubApiClient apiClient, ITribeViewModelMapper tribeViewModelMapper)
        : base(apiClient)
    {
        this.tribeViewModelMapper = tribeViewModelMapper;
        this.apiClient = apiClient;
    }

    public async Task<Response<IList<TribeViewModel>>> GetAll()
    {
        Response<IList<TribeViewModel>> response;

        try
        {
            IList<TribeDto>? tribeDtos = await this.apiClient.ApiTribesGetAsync();

            response = new Response<IList<TribeViewModel>>
            {
                Data = this.tribeViewModelMapper.Map(tribeDtos),
                Success = true
            };
        }
        catch (ApiException<ProblemDetails> exception)
        {
            response = this.GetApiExceptionResponse<IList<TribeViewModel>>(exception);
        }

        return response;
    }
}