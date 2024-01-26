namespace ProjectHub.Blazor.Constants;

using System.ComponentModel;

public enum ProjectStatus
{
    [Description("Fertig")] Done,
    [Description("In Bearbeitung")] InProgress,
    [Description("Neu")] New
}