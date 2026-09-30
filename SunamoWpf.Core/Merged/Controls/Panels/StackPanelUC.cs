#define ASYNC
namespace SunamoWpf.Controls.Panels;

public class StackPanelUC : UserControl, IUserControl
{
    public StackPanel sp = new StackPanel();

    public string Title => string.Empty;

    public void Init()
    {
        Content = sp;
    }
}