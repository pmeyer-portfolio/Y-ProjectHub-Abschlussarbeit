#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Blazor.Forms;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProjectHub.Blazor.Services.Base;

public partial class ProjectCreateForm
{
    [Parameter]
    public required ProjectCreateDto ProjectCreateDto { get; set; }

    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private void HandleTribeSelected(int selectedId)
    {
        this.ProjectCreateDto.TribeId = selectedId;
    }

    private void HandleLanguageSelected(IList<int> selectedIds)
    {
        this.ProjectCreateDto.Languages = selectedIds;
    }
}