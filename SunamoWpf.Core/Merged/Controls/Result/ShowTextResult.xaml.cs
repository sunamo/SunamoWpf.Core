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
    public void FocusOnMainElement()
    {
        txtResult.Focus();
    }
    public ShowTextResult(string text) : this()
    {
        txtResult.Text = text;
    }
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
    public string Title => Translate.FromKey(XlfKeys.ShowResult);
    public event VoidBoolNullable ChangeDialogResult;
    public void Accept(object input)
    {
        DialogResult = true;
    }
    public void Init()
    {
    }
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
        //SunamoTemplateLogger.Instance.CopiedToClipboard(Translate.FromKey(XlfKeys.Result));
    }
    #endregion
}
