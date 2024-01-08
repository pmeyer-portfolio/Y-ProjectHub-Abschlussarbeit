namespace ProjectHub.Blazor.Initializer;

using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public class DropDownDataGridInitializer : IDropDownDataGridInitializer
{
    private Response<IList<ProgrammingLanguageDto>> programmingLanguageResponse = new() { Success = true };

    private Response<IList<TribeDto>> tribeResponse = new() { Success = true };
    public required ITribeService TribeService { get; init; }
    public required IProgrammingLanguageService ProgrammingLanguageService { get; init; }

    public DropDownDataGridInitializer(ITribeService tribeService, IProgrammingLanguageService programmingLanguageService)
    {
        this.TribeService = tribeService;
        this.ProgrammingLanguageService = programmingLanguageService;
    }

    public async Task<IList<TribeDto>> InitializeTribes()
    {
        this.tribeResponse = await this.TribeService.GetAll();

        IList<TribeDto> tribeDtos = new List<TribeDto>();

        if (this.tribeResponse is not { Success: true, Data: not null })
        {
            return tribeDtos;
        }

        tribeDtos = this.tribeResponse.Data;
        tribeDtos.Insert(0, new TribeDto
        {
            Id = -1,
            Name = PlaceHolder.NotAssigned
        });

        return tribeDtos;
    }

    public async Task<IList<ProgrammingLanguageDto>> InitializeProgrammingLanguages()
    {
        this.programmingLanguageResponse = await this.ProgrammingLanguageService.GetAll();

        IList<ProgrammingLanguageDto> programmingLanguageDtos = new List<ProgrammingLanguageDto>();

        if (this.programmingLanguageResponse is not { Success: true, Data: not null })
        {
            return programmingLanguageDtos;
        }

        programmingLanguageDtos = this.programmingLanguageResponse.Data;
        programmingLanguageDtos.Insert(0, new ProgrammingLanguageDto
        {
            Id = -1,
            Name = PlaceHolder.NotSpecified
        });

        return programmingLanguageDtos;
    }
}