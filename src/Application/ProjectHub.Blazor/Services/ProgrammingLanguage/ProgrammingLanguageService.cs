namespace ProjectHub.Blazor.Services.ProgrammingLanguage;

using ProjectHub.Blazor.Mappers.ProgrammingLanguage;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Services.Base;

public class ProgrammingLanguageService : BaseHttpService, IProgrammingLanguageService
{
    private IProgrammingLanguageViewModelMapper programmingLanguageViewModelMapper { get; }

    public ProgrammingLanguageService(IProjectHubApiClient apiClient,
        IProgrammingLanguageViewModelMapper programmingLanguageViewModelMapper)
        : base(apiClient)
    {
        this.programmingLanguageViewModelMapper = programmingLanguageViewModelMapper;
        this.apiClient = apiClient;
    }

    public async Task<Response<IList<ProgrammingLanguageViewModel>>> GetAll()
    {
        Response<IList<ProgrammingLanguageViewModel>> response;

        try
        {
            IList<ProgrammingLanguageDto>? programmingLanguageDtos =
                await this.apiClient.ApiProgrammingLanguagesGetAsync();
            IList<ProgrammingLanguageViewModel> programmingLanguageViewModels =
                this.programmingLanguageViewModelMapper.Map(programmingLanguageDtos);

            response = new Response<IList<ProgrammingLanguageViewModel>>
            {
                Data = programmingLanguageViewModels,
                Success = true
            };
        }
        catch (ApiException<ProblemDetails> exception)
        {
            response = this.GetApiExceptionResponse<IList<ProgrammingLanguageViewModel>>(exception);
        }

        return response;
    }
}