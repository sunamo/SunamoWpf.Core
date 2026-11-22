#define ASYNC
namespace SunamoWpf.Controls.Result;

/// <summary>
/// Represents the founded result view model type.
/// </summary>
public class FoundedResultViewModel
{
    /// <summary>
    /// The do.
    /// </summary>
    public static event Action<FoundedResultActions> Do;

    /// <summary>
    /// Gets the copy to clipboard founded.
    /// </summary>
    public ICommand CopyToClipboardFounded => new RelayCommand(() =>
    {
        Do(FoundedResultActions.CopyToClipboardFounded);
    });
}