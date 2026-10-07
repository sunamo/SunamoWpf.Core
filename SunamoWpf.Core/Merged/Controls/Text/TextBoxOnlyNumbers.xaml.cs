#define ASYNC
namespace SunamoWpf;

public partial class TextBoxOnlyNumbers : UserControl
{
    #region Rewrite to pure cs. With xaml is often problems without building
    public string Text
    {
        set
        {
            txt.Text = CharHelper.OnlyDigits(value);
        }
        get
        {
            return txt.Text;
        }
    }

    public TextBoxOnlyNumbers()
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
        txt.TextChanged += Txt_TextChanged;
    }

    private void Txt_TextChanged(object sender, TextChangedEventArgs eventArgs)
    {
        txt.Text = CharHelper.OnlyDigits(txt.Text);
    }
    #endregion
}
