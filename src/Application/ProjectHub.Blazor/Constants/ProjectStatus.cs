namespace ProjectHub.Blazor.Constants;

using System.ComponentModel;
using System.Reflection;

public enum ProjectStatus
{
    [Description("Fertig")]
    Done,
    [Description("In Bearbeitung")]
    InProgress,
    [Description("Neu")]
    New
}
