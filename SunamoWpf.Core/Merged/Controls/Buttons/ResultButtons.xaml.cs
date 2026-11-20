#define ASYNC
namespace SunamoWpf.Controls;

public partial class ResultButtons : UserControl
{
    public event Action AllRightClick;
    // as event - useful when output will be editable
    public event Action CopyToClipboard;
    public ResultButtons()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception)
        {
#if DEBUG
            Debugger.Break();
#endif
        }
        Loaded += ResultButtons_Loaded;
    }
    private void ResultButtons_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        btnAllRight.Content = "AllRight" + "!";
        btnCopyToClipboard.Content = "Copy text to clipboard";
    }
    private void btnCopyToClipboard_Click(object sender, RoutedEventArgs eventArgs)
    {
        CopyToClipboard();
    }
    private void btnAllRight_Click(object sender, RoutedEventArgs eventArgs)
    {
        AllRightClick();
    }
}
