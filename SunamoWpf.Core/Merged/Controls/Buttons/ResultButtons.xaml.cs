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
    private void ResultButtons_Loaded(object sender, RoutedEventArgs e)
    {
        btnAllRight.Content = Translate.FromKey(XlfKeys.AllRight) + "!";
        btnCopyToClipboard.Content = Translate.FromKey(XlfKeys.CopyTextToClipboard);
    }
    private void btnCopyToClipboard_Click(object sender, RoutedEventArgs e)
    {
        CopyToClipboard();
    }
    private void btnAllRight_Click(object sender, RoutedEventArgs e)
    {
        AllRightClick();
    }
}
