namespace ProjectHub.Blazor.Components.DataGrids;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Models.Tribe;

public partial class TribeDropDownDataGrid
{
    [Parameter]
    public string? CurrentValue { get; set; }

    [Parameter]
    public EventCallback<TribeViewModel> OnTribeSelected { get; set; }

    [Inject]
    public required IProjectHubDataInitializer ProjectHubDataInitializer { get; set; }

    private IList<TribeViewModel>? Tribes { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.Tribes = await this.ProjectHubDataInitializer.InitializeTribes();
    }

    private void OnValueChanged(object value)
    {
        if (value is TribeViewModel tribeViewModel)
        {
            this.OnTribeSelected.InvokeAsync(tribeViewModel);
        }
    }
}