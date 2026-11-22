#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class ShowCodeResultUC : UserControl
{
    /// <summary>
    /// Initializes a new instance of the show code result UC class.
    /// </summary>
    public ShowCodeResultUC()
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
    }
}
