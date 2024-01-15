namespace ProjectHub.Blazor.Models
{
    using Radzen;

    public static class ProjectDetailsDialogOptions
    {
        public static DialogOptions GetDefault()
        {
            return new DialogOptions
            {
                Width = "800px",
                Height = "680px",
                Resizable = true,
                Draggable = false,
                CloseDialogOnEsc = false,
                ShowClose = true,
                ShowTitle = true,
                CssClass = "default-dialog-position"
            };
        }

        public static DialogOptions GetEdit()
        {
            return new DialogOptions
            {
                Width = "460px",
                Height = "auto",
                CloseDialogOnEsc = false,
                Draggable = false,
                CssClass = "edit-dialog-position"
            };
        }
    }
}

