namespace ProjectHub.Blazor.Components.DataGrids;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Services.Base;

public partial class ProgrammingLanguageDropDownDataGrid
{
    [Parameter]
    public EventCallback<IList<int>> OnItemSelected { get; set; }

    [Inject]
    public IDropDownDataGridInitializer DropDownDataGridInitializer { get; set; } = null!;

    public IList<ProgrammingLanguageDto>? ProgrammingLanguages { get; set; }

    protected override async Task OnInitializedAsync()
    {
        this.ProgrammingLanguages = await this.DropDownDataGridInitializer.InitializeProgrammingLanguages();
    }

    private void OnValueChanged(object value)
    {
        if (value is EnumerableQuery<int> objectList)
        {
            this.OnItemSelected.InvokeAsync(objectList.ToList());
        }
    }
}