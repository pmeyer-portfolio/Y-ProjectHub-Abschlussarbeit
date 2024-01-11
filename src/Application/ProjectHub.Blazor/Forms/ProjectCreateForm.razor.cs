namespace ProjectHub.Blazor.Forms;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProjectHub.Blazor.Services.Base;

public partial class ProjectCreateForm
{
    [Parameter]
    public required ProjectCreateDto ProjectCreateDto { get; set; }

    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    private void HandleTribeSelected(int selectedId)
    {
        this.ProjectCreateDto.TribeId = selectedId;
    }

    private void HandleLanguageSelected(IList<int> selectedIds)
    {
        this.ProjectCreateDto.Languages = selectedIds;
    }
    private void OnChange(string input)
    {
        this.ProjectCreateDto.Description = input;
    }
}