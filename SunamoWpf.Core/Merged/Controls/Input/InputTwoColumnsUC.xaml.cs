#define ASYNC
namespace SunamoWpf.Controls;

public partial class InputTwoColumnsUC : UserControl, IControlWithResultWpf, IControlWithResultDebugWpf, IUserControl
{
    static Type type = typeof(InputTwoColumnsUC);
    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        txt1.Focus();
    }
    /// <summary>
    /// The txt first.
    /// </summary>
    public TextBox txtFirst
    {
        get
        {
            return txt1;
        }
    }
    /// <summary>
    /// The txt second.
    /// </summary>
    public TextBox txtSecond
    {
        get
        {
            return txt2;
        }
    }
    const int rowsCount = 2;
    List<TextBox> checkForContent = new List<TextBox>();
    /// <summary>
    /// Initializes a new instance of the input two columns UC class.
    /// </summary>
    public InputTwoColumnsUC()
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
        dialogButtons.ChangeDialogResult += DialogButtons_ChangeDialogResult;
        uc_Loaded(null, null);
    }
    /// <summary>
    /// Initializes a new instance of the input two columns UC class.
    /// </summary>
    /// <param name="neededRows">The needed rows.</param>
    public InputTwoColumnsUC(int neededRows) : this()
    {
        if (neededRows > rowsCount)
        {
            ThrowEx.BadMappedXaml("InputTwoColumnsUC", "It needs more rows than it exists");
        }
        else
        {
            TextBlock textBlock = null;
            TextBox txt = null;
            Visibility visible = Visibility.Visible;
            for (int index = 1; index < rowsCount + 1; index++)
            {
                textBlock = FrameworkElementHelper.FindName<TextBlock>(this, ControlNames.tb, index);
                txt = FrameworkElementHelper.FindName<TextBox>(this, ControlNames.txt, index);
                if (visible == Visibility.Visible)
                {
                    checkForContent.Add(txt);
                }
                textBlock.Visibility = txt.Visibility = visible;
                if (index == neededRows)
                {
                    visible = Visibility.Collapsed;
                }
            }
        }
    }
    private void DialogButtons_ChangeDialogResult(bool? result)
    {
        if (result.HasValue)
        {
            if (!result.Value)
            {
                ////////DebugLogger.Instance.ClipboardOrDebug(methodName + "Dialog result set to " + false);
                DialogResult = false;
                return;
            }
        }
        bool allOk = true;
        foreach (var item in checkForContent)
        {
            if (string.IsNullOrEmpty(item.Text))
            {
                WpfLogger.Error("All of the inputs must be filled");
                ////////DebugLogger.Instance.ClipboardOrDebug(methodName + "Something was not filled in");
                allOk = false;
            }
        }
        if (allOk)
        {
            DialogResult = true;
            ////////DebugLogger.Instance.ClipboardOrDebug(methodName + "Dialog result set to " + true);
        }
    }
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="textFirst">The text first.</param>
    /// <param name="textSecond">The text second.</param>
    public void Init(string textFirst, string textSecond)
    {
        tb1.Text = textFirst;
        tb2.Text = textSecond;
    }
    /// <summary>
    /// The dialog result.
    /// </summary>
    public bool? DialogResult
    {
        set
        {
            if (ChangeDialogResult != null)
            {
                ChangeDialogResult(value);
            }
        }
    }
    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => "InputTwoColumns";
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
    /// <summary>
    /// A1 must be ABT<string, string>
    /// </summary>
    /// <param name="input"></param>
    public void Accept(object input)
    {
        ABT<string, string> data = (ABT<string, string>)input;
        txtFirst.Text = data.A;
        txtSecond.Text = data.B;
        // Cant be, window must be already showned as dialog
        //DialogResult = true;
    }
    //
    /// <summary>
    /// Count of handlers change dialog result.
    /// </summary>
    /// <returns>The count of handlers change dialog result result.</returns>
    public int CountOfHandlersChangeDialogResult()
    {
        return RuntimeHelper.GetInvocationList(ChangeDialogResult).Count;
    }
    /// <summary>
    /// Attach change dialog result.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="throwException">The throw exception.</param>
    public void AttachChangeDialogResult(VoidBoolNullable handler, bool throwException = true)
    {
        RuntimeHelper.AttachChangeDialogResult(this, handler, throwException);
    }
    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
    }
    /// <summary>
    /// Uc loaded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
    {
    }
}
