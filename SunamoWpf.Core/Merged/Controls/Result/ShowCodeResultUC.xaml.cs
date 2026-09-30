#define ASYNC
namespace SunamoWpf.Controls.Result;

public partial class ShowCodeResultUC : UserControl
{
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
