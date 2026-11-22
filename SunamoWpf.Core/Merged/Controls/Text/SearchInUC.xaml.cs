#define ASYNC
namespace SunamoWpf.Controls.Text;

public partial class SearchInUC : UserControl
{
    /// <summary>
    /// Initializes a new instance of the search in UC class.
    /// </summary>
    public SearchInUC()
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

        Loaded += SearchInUC_Loaded;
    }

    private void SearchInUC_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        cbSearchInContentUC.Name = Name + "Cb";
        chbSearchInContent.Name = Name + "Chb";

        chbSearchInContent.Checked += ChbSearchInContent_Checked;
    }

    private void ChbSearchInContent_Checked(object sender, RoutedEventArgs eventArgs)
    {

    }

    /// <summary>
    /// The border brush.
    /// </summary>
    public Brush BorderBrush
    {
        set
        {
            b.BorderBrush = value;
        }
    }
}
