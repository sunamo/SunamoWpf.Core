#define ASYNC
namespace SunamoWpf.Controls.Visualization;

public class ProgressBarWithLabel : UserControl
{
    public System.Windows.Controls.ProgressBar pb = null;
    
    public TextBlock tb = null;
    public const string prefixWith = "   ";

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