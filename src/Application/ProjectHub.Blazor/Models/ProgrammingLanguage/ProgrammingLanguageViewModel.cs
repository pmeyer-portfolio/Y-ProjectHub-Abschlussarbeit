namespace ProjectHub.Blazor.Models.ProgrammingLanguage;

using ProjectHub.Blazor.Constants;

public class ProgrammingLanguageViewModel : BaseViewModel
{
    public static ProgrammingLanguageViewModel NotSpecified { get; } =
        new() { Id = -1, Name = PlaceHolder.NotSpecified };
}