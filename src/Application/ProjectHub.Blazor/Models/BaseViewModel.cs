namespace ProjectHub.Blazor.Models;

public abstract class BaseViewModel : IComparable<BaseViewModel>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int CompareTo(BaseViewModel? baseViewModel)
    {
        if (baseViewModel == null)
        {
            return 1;
        }

        return string.Compare(this.Name, baseViewModel.Name, StringComparison.Ordinal);
    }
}