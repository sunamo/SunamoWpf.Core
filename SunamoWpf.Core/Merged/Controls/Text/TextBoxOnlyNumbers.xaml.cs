#define ASYNC
namespace SunamoWpf;

public partial class TextBoxOnlyNumbers : UserControl
{
    #region Rewrite to pure cs. With xaml is often problems without building
    /// <summary>
    /// The text.
    /// </summary>
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

    /// <summary>
    /// Initializes a new instance of the text box only numbers class.
    /// </summary>
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
