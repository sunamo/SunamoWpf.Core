#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class NoResultsFound : UserControl
{
    public NoResultsFound()
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

        if (string.IsNullOrEmpty(tbNoResultsFound.Text))
        {
            tbNoResultsFound.Text = Translate.FromKey(XlfKeys.NoResultsFound);
        }
    }
    public NoResultsFound(string what) : this()
    {
        tbNoResultsFound.Text = "No " + what + " found";
    }
}
