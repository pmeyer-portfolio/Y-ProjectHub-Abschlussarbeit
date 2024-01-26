namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Models.Project;
using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Project.Interfaces;

public partial class Filter
{
    private string? tribeNameFilterValue, statusFilterValue, programmingLanguageFilterValue;
    private DateTime? fromDateFilterValue, toDateFilterValue, specificDateFilterValue;
    private bool selectBarValue = false, filterByRange = true;

    [Inject] 
    public IProjectHubDataInitializer ProjectHubDataInitializer { get; set; } = null!;
    [Inject] 
    public IProjectFilterService ProjectFilterService { get; set; } = null!;
    [Parameter] 
    public EventCallback<IList<ProjectViewModel>> OnFilterChanged { get; set; }
    [Parameter] 
    public IList<ProjectViewModel> Projects { get; set; } = new List<ProjectViewModel>();

    public EventCallback<string> OnSelected { get; set; }
    private IList<TribeViewModel>? Tribes { get; set; }
    private IList<ProgrammingLanguageViewModel>? ProgrammingLanguages { get; set; }
    private IList<ProjectStatusViewModel>? ProjectStatusViewModels{ get; set; }
    private IList<ProjectViewModel> FilteredProjects { get; set; } = new List<ProjectViewModel>();

    protected override async Task OnInitializedAsync()
    {
        this.Tribes = await this.ProjectHubDataInitializer.InitializeTribes();
        this.ProgrammingLanguages = await this.ProjectHubDataInitializer.InitializeProgrammingLanguages();
        this.ProjectStatusViewModels = await this.ProjectHubDataInitializer.InitializeStatus();
    }
    private void SelectBarChange()
    {
        this.filterByRange = !this.selectBarValue;
        this.ClearDate();
    }

    private void ClearDate()
    {
        this.toDateFilterValue = null;
        this.fromDateFilterValue = null;
        this.specificDateFilterValue = null;

        this.StateHasChanged();
    }

    private async Task OnFilter()
    {
        ProjectFilterModel projectFilterModel = new()
        {
            TribeName = this.tribeNameFilterValue,
            Status = this.statusFilterValue,
            ProgrammingLanguage = this.programmingLanguageFilterValue,
            SpecificDateTime = this.specificDateFilterValue,
            FromDateTime = this.fromDateFilterValue,
            ToDateTime = this.toDateFilterValue,
        };

        this.FilteredProjects = this.ProjectFilterService.Filter(projectFilterModel, this.Projects);

        if (this.OnFilterChanged.HasDelegate)
        {
            await this.OnFilterChanged.InvokeAsync(this.FilteredProjects);
        }
    }

    private async Task OnClear()
    {
        this.tribeNameFilterValue = null;
        this.statusFilterValue = null;
        this.programmingLanguageFilterValue = null;
        this.toDateFilterValue = null;
        this.fromDateFilterValue = null;
        this.specificDateFilterValue = null;

        this.StateHasChanged();

        this.FilteredProjects = this.Projects;

        if (this.OnFilterChanged.HasDelegate)
        {
            await this.OnFilterChanged.InvokeAsync(this.FilteredProjects);
        }
    }

    private void OnValueChange(object args)
    {
        if (args is string stringValue)
        {
            this.OnSelected.InvokeAsync(stringValue);
        }
    }
}
