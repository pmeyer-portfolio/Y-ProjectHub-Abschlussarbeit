using Microsoft.AspNetCore.Components;

namespace ProjectHub.Blazor.Shared;

public partial class SurveyPrompt
{
    [Parameter] public string? Title { get; set; }
}