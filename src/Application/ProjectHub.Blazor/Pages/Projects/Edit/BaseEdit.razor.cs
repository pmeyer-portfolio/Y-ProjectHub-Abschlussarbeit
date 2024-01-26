namespace ProjectHub.Blazor.Pages.Projects.Edit;

using Microsoft.AspNetCore.Components;
using ProjectHub.Blazor.Models.Project;
using Radzen;

public abstract class BaseEdit : ComponentBase
{
    [Inject]
    public DialogService DialogService { get; set; } = null!;

    [Parameter]
    public required ProjectDetailsViewModel ProjectDetailsViewModel { get; set; }

    protected abstract void OnOkClick();
}