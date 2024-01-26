namespace ProjectHub.Blazor.Components.DataGrids;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Models.Project;

public partial class StatusDropDownDataGrid
{
    private IList<ProjectStatusViewModel> projectStatusViewModels = new List<ProjectStatusViewModel>();

    [Parameter]
    public string? CurrentValue { get; set; }

    [Parameter]
    public EventCallback<ProjectStatusViewModel> OnStatusSelected { get; set; }

    [Inject]
    public required IProjectHubDataInitializer ProjectHubDataInitializer { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.projectStatusViewModels = await this.ProjectHubDataInitializer.InitializeStatus();
    }

    private void OnValueChanged(object value)
    {
        if (value is ProjectStatusViewModel tribeViewModel)
        {
            this.OnStatusSelected.InvokeAsync(tribeViewModel);
        }
    }
}