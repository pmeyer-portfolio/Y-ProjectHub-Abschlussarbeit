namespace ProjectHub.Blazor.Pages.Projects;

using Microsoft.AspNetCore.Components;

public partial class Edit
{
    [Parameter]
    public string? Value { get; set; }

    public string? StatusValue { get; set; }

    public EventCallback<string> OnSelected { get; set; }

    private void OnValueChange(object args)
    {
        if (args is string stringValue)
        {
            this.OnSelected.InvokeAsync(stringValue);
        }
    }
}
