namespace ProjectHub.Blazor.Models;

using System.Reflection;
using Microsoft.AspNetCore.Components;

public class ProjectDetailsViewModel : ProjectViewModel
{
    public string? CreatorEmail { get; set; }
    public MarkupString? Description { get; init; }

    public void UpdateProperty(string propertyName, object newValue)
    {
        PropertyInfo? property = this.GetType().GetProperty(propertyName);
        if (property != null && property.CanWrite)
        {
            property.SetValue(this, newValue, null);
        }
    }
}