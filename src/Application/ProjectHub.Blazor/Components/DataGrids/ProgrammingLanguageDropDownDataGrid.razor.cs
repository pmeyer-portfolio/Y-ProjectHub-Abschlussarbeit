namespace ProjectHub.Blazor.Components.DataGrids;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public partial class ProgrammingLanguageDropDownDataGrid
{
    private Response<IList<ProgrammingLanguageDto>> response = new() { Success = true };

    public IList<ProgrammingLanguageDto>? ProgrammingLanguages { get; set; }

    [Inject]
    public required IProgrammingLanguageService Service { get; set; }

    [Parameter]
    public EventCallback<IList<int>> OnItemSelected { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await this.Initialize();
    }

    private void OnValueChanged(object value)
    {
        if (value is EnumerableQuery<int> objectList)
        {
            this.OnItemSelected.InvokeAsync(objectList.ToList());
        }
    }

    private async Task Initialize()
    {
        this.response = await this.Service.GetAll();
        {
            if (this.response.Success)
            {
                this.ProgrammingLanguages = this.response.Data;
                this.ProgrammingLanguages?.Insert(0, new ProgrammingLanguageDto
                {
                    Id = -1,
                    Name = "Keine Spezifikation"
                });
            }
        }
    }
}