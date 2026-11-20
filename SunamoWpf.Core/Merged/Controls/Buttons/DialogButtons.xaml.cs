#define ASYNC
namespace SunamoWpf.Controls;

public partial class DialogButtons : UserControl, IControlWithResultWpf
{
    #region MyRegion
    /// <summary>
    /// Initializes a new instance of the dialog buttons class.
    /// </summary>
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

    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        btnOk.Focus();
    }

    /// <summary>
    /// The custom control.
    /// </summary>
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

    /// <summary>
    /// The dialog result.
    /// </summary>
    public bool? DialogResult
    {
        set
        {
            ChangeDialogResult(value);
        }
    }

    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;

    /// <summary>
    /// The is enabled btn ok.
    /// </summary>
    public bool IsEnabledBtnOk
    {
        set
        {
            btnOk.IsEnabled = value;
        }
    }

    /// <summary>
    /// The clicked ok.
    /// </summary>
    public bool clickedOk = false;
    /// <summary>
    /// The clicked apply.
    /// </summary>
    public bool clickedApply = false;
    /// <summary>
    /// The clicked cancel.
    /// </summary>
    public bool clickedCancel = false;


    /// <summary>
    /// The is enabled btn apply.
    /// </summary>
    public bool IsEnabledBtnApply
    {
        set
        {
            btnApply.IsEnabled = value;
        }
    }

    /// <summary>
    /// The visibility btn apply.
    /// </summary>
    public Visibility VisibilityBtnApply
    {
        set
        {
            btnApply.Visibility = value;
        }
    }

    private void btnCancel_Click(object sender, RoutedEventArgs eventArgs)
    {
        clickedCancel = true;
        DialogResult = false;
    }

    private void btnOk_Click(object sender, RoutedEventArgs eventArgs)
    {
        clickedOk = true;
        DialogResult = true;
    }

    private void btnApply_Click(object sender, RoutedEventArgs eventArgs)
    {
        clickedApply = true;
        DialogResult = null;
    }

    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Accept(object input)
    {
        ThrowEx.Custom("Only buttons can be accepted because it has no data for accept" + ".");
    }

    static Type type = typeof(DialogButtons);
}
#endregion

