namespace ProjectHub.Blazor.Components.DataGrids;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Services.Base;

public partial class TribeDropDownDataGrid
{
    [Parameter]
    public EventCallback<int> OnTribeIdSelected { get; set; }

    [Inject]
    public IDropDownDataGridInitializer DropDownDataGridInitializer { get; set; } = null!;

    public IList<TribeDto>? Tribes { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.Tribes = await this.DropDownDataGridInitializer.InitializeTribes();
    }

    private void OnValueChanged(object value)
    {
        if (value is int intValue)
        {
            this.OnTribeIdSelected.InvokeAsync(intValue);
        }
    }
}