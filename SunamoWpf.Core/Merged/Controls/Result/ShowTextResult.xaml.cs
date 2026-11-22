#define ASYNC
namespace SunamoWpf.Controls;

public partial class ShowTextResult : UserControl, IUserControl, IControlWithResultWpf, IUserControlWithSizeChange
{
    #region Rewrite to pure cs. With xaml is often problems without building
    /// <summary>
    /// Must be empty constructor due to creating in SetMode()
    /// </summary>
    public ShowTextResult()
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
        // Nechce se mi tu šaškovat s generickým počítáním dle screenu
        Width = 1024;
        Height = 768;
    }
    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        txtResult.Focus();
    }
    /// <summary>
    /// Initializes a new instance of the show text result class.
    /// </summary>
    /// <param name="text">The text.</param>
    public ShowTextResult(string text) : this()
    {
        txtResult.Text = text;
    }
    /// <summary>
    /// The dialog result.
    /// </summary>
    public bool? DialogResult
    {
        set
        {
            // In case ShowTextResult I dont need any handler, therefore checking
            if (ChangeDialogResult != null)
            {
                // must have value because ResultButtons dont close window itself
                ChangeDialogResult(value);
            }
        }
    }
    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => "ShowResult";
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Accept(object input)
    {
        DialogResult = true;
    }
    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
    }
    /// <summary>
    /// On size changed.
    /// </summary>
    /// <param name="maxSize">The max size.</param>
    public void OnSizeChanged(DesktopSize maxSize)
    {
        txtResult.Height = rowGrowing.ActualHeight;
    }
    private void resultButtons_AllRightClick()
    {
        DialogResult = true;
    }
    private void resultButtons_CopyToClipboard()
    {
        ClipboardService.SetText(txtResult.Text);
    }
    #endregion
}
