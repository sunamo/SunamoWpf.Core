#define ASYNC
namespace SunamoWpf.Controls.Result;

public class FoundedResultViewModel
{
    public static event Action<FoundedResultActions> Do;

    public ICommand CopyToClipboardFounded => new RelayCommand(() =>
    {
        Do(FoundedResultActions.CopyToClipboardFounded);
    });
}