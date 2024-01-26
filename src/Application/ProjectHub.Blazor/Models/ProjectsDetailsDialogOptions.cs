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

        public static DialogOptions GetTribeOptions()
        {
            return new DialogOptions
            {
                Width = "460px",
                Height = "auto",
                CloseDialogOnEsc = false,
                Draggable = false,
                CssClass = "edit-tribe-dialog-position"
            };
        }

        public static DialogOptions GetProgrammingLanguagesOptions()
        {
            return new DialogOptions
            {
                Width = "460px",
                Height = "auto",
                CloseDialogOnEsc = false,
                Draggable = false,
                CssClass = "edit-programmingLanguages-dialog-position"
            };
        }

        public static DialogOptions GetStatusOptions()
        {
            return new DialogOptions
            {
                Width = "460px",
                Height = "auto",
                CloseDialogOnEsc = false,
                Draggable = false,
                CssClass = "edit-status-dialog-position"
            };
        }

        public static DialogOptions GetTitleOptions()
        {
            return new DialogOptions
            {
                Width = "460px",
                Height = "auto",
                CloseDialogOnEsc = false,
                Draggable = false,
                CssClass = "edit-title-dialog-position"
            };
        }

        public static DialogOptions GetDescriptionOptions()
        {
            return new DialogOptions
            {
                
                Width = "700px",
                Height = "auto",
                Resizable = true,
                CloseDialogOnEsc = false,
                Draggable = true,
                CssClass = "edit-description-dialog-position"
            };
        }
    }
}