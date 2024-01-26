namespace ProjectHub.Blazor.Models.Project;

using System.Reflection;
using Microsoft.AspNetCore.Components;

public class ProjectDetailsViewModel : ProjectViewModel
{
    public string? CreatorEmail { get; init; }
    public MarkupString Description { get; set; }
}