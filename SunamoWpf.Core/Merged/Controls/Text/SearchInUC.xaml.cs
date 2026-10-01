#define ASYNC
namespace SunamoWpf.Controls.Text;

public partial class SearchInUC : UserControl
{
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

    private void SearchInUC_Loaded(object sender, RoutedEventArgs e)
    {
        cbSearchInContentUC.Name = Name + "Cb";
        chbSearchInContent.Name = Name + "Chb";

        chbSearchInContent.Checked += ChbSearchInContent_Checked;
    }

    private void ChbSearchInContent_Checked(object sender, RoutedEventArgs e)
    {

    }

    public Brush BorderBrush
    {
        set
        {
            b.BorderBrush = value;
        }
    }
}
