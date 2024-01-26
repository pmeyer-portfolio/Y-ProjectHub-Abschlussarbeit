namespace ProjectHub.Blazor.Initializer;

using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Extensions;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.ProgrammingLanguage;
using ProjectHub.Blazor.Services.Tribe;

public class ProjectHubDataInitializer : IProjectHubDataInitializer
{
    private Response<IList<ProgrammingLanguageViewModel>> programmingLanguageResponse = new() { Success = true };

    private Response<IList<TribeViewModel>> tribeResponse = new() { Success = true };
    public required ITribeService TribeService { get; init; }
    public required IProgrammingLanguageService ProgrammingLanguageService { get; init; }

    public ProjectHubDataInitializer(ITribeService tribeService, IProgrammingLanguageService programmingLanguageService)
    {
        this.TribeService = tribeService;
        this.ProgrammingLanguageService = programmingLanguageService;
    }

    public async Task<IList<TribeViewModel>> InitializeTribes()
    {
        this.tribeResponse = await this.TribeService.GetAll();

        IList<TribeViewModel> tribeModels = new List<TribeViewModel>();

        if (this.tribeResponse is not { Success: true, Data: not null })
        {
            return tribeModels;
        }

        tribeModels = this.tribeResponse.Data;
        tribeModels.Insert(0, new TribeViewModel
        {
            Id = -1,
            Name = PlaceHolder.NotAssigned
        });

        return tribeModels;
    }

    public async Task<IList<ProjectStatusViewModel>> InitializeStatus()
    {
        return await Task.Run(() => Enum.GetValues(typeof(ProjectStatus))
            .Cast<ProjectStatus>()
            .Select(e => new ProjectStatusViewModel
            {
                Name = e.GetDescription(),
               Id = (int)e
            }).ToList());
    }

    public async Task<IList<ProgrammingLanguageViewModel>> InitializeProgrammingLanguages()
    {
        this.programmingLanguageResponse = await this.ProgrammingLanguageService.GetAll();

        IList<ProgrammingLanguageViewModel> programmingLanguageViewModels = new List<ProgrammingLanguageViewModel>();

        if (this.programmingLanguageResponse is not { Success: true, Data: not null })
        {
            return programmingLanguageViewModels;
        }

        programmingLanguageViewModels = this.programmingLanguageResponse.Data;
        programmingLanguageViewModels.Insert(0, new ProgrammingLanguageViewModel
        {
            Id = -1,
            Name = PlaceHolder.NotSpecified
        });

        return programmingLanguageViewModels;
    }
}