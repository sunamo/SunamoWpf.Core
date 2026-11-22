#define ASYNC
namespace SunamoWpf.Controls.Panels;

/// <summary>
/// Represents the stack panel UC type.
/// </summary>
public class StackPanelUC : UserControl, IUserControl
{
    /// <summary>
    /// The sp.
    /// </summary>
    public StackPanel sp = new StackPanel();

    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => string.Empty;

    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
        Content = sp;
    }
}