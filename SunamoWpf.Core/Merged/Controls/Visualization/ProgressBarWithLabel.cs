#define ASYNC
namespace SunamoWpf.Controls.Visualization;

/// <summary>
/// Represents the progress bar with label type.
/// </summary>
public class ProgressBarWithLabel : UserControl
{
    /// <summary>
    /// The pb.
    /// </summary>
    public System.Windows.Controls.ProgressBar pb = null;
    
    /// <summary>
    /// The tb.
    /// </summary>
    public TextBlock tb = null;
    /// <summary>
    /// The prefix with constant.
    /// </summary>
    public const string prefixWith = "   ";

    /// <summary>
    /// The tb text.
    /// </summary>
    public string TbText
    {
        get
        {
            return WpfApp.cd.Invoke<string>(() => tb.Text);
        }
        set
        {
            if (string.IsNullOrWhiteSpace(TbText))
            {
                tb.Text = string.Empty;
            }
            else
            {
                WpfApp.cd.Invoke(() => tb.Text = prefixWith + value);
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the progress bar with label class.
    /// </summary>
    public ProgressBarWithLabel()
    {
        StackPanel stackPanel = new StackPanel();
        stackPanel.Orientation = Orientation.Horizontal;

        pb = new System.Windows.Controls.ProgressBar();
        pb.Width = 300;
        //pb.Value = 100;

        stackPanel.Children.Add(pb);

        

        tb = new TextBlock();
        tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
        tb.Width = 300;
        stackPanel.Children.Add(tb);

        Content = stackPanel;
    }


}