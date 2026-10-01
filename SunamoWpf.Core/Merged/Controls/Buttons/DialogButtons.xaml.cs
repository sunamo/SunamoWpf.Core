#define ASYNC
namespace SunamoWpf.Controls;

public partial class DialogButtons : UserControl, IControlWithResultWpf
{
    #region MyRegion
    public DialogButtons()
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

    public void FocusOnMainElement()
    {
        btnOk.Focus();
    }

    public UIElement CustomControl
    {
        set
        {
            grid.Children.Insert(0, value);
        }
        get
        {
            return grid.Children[0];
        }
    }

    public bool? DialogResult
    {
        set
        {
            ChangeDialogResult(value);
        }
    }

    public event VoidBoolNullable ChangeDialogResult;

    public bool IsEnabledBtnOk
    {
        set
        {
            btnOk.IsEnabled = value;
        }
    }

    public bool clickedOk = false;
    public bool clickedApply = false;
    public bool clickedCancel = false;


    public bool IsEnabledBtnApply
    {
        set
        {
            btnApply.IsEnabled = value;
        }
    }

    public Visibility VisibilityBtnApply
    {
        set
        {
            btnApply.Visibility = value;
        }
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        clickedCancel = true;
        DialogResult = false;
    }

    private void btnOk_Click(object sender, RoutedEventArgs e)
    {
        clickedOk = true;
        DialogResult = true;
    }

    private void btnApply_Click(object sender, RoutedEventArgs e)
    {
        clickedApply = true;
        DialogResult = null;
    }

    public void Accept(object input)
    {
        ThrowEx.Custom(Translate.FromKey(XlfKeys.OnlyButtonsCanBeAcceptedBecauseItHasNoDataForAccept) + ".");
    }

    static Type type = typeof(DialogButtons);
}
#endregion

