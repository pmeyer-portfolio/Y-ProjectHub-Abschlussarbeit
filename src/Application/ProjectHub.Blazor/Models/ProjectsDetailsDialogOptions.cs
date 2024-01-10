using Radzen;

namespace ProjectHub.Blazor.Models;

public abstract class ProjectDetailsDialogOptions
{
    public static DialogOptions GetDefault()
    {
        return new DialogOptions
        {
            Width = "700px",
            Height = "512px",
            Resizable = true,
            Draggable = true,
            CloseDialogOnEsc = true,
            ShowClose = true,
            ShowTitle = true,
        };
    }
}