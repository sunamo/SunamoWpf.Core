#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class NoResultsFound : UserControl
{
    /// <summary>
    /// Initializes a new instance of the no results found class.
    /// </summary>
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
            tbNoResultsFound.Text = "NoResultsFound";
        }
    }
    /// <summary>
    /// Initializes a new instance of the no results found class.
    /// </summary>
    /// <param name="what">The what.</param>
    public NoResultsFound(string what) : this()
    {
        tbNoResultsFound.Text = "No " + what + " found";
    }
}
