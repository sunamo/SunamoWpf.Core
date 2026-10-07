#define ASYNC
namespace SunamoWpf.Controls;

public partial class InputTwoColumnsUC : UserControl, IControlWithResultWpf, IControlWithResultDebugWpf, IUserControl
{
    static Type type = typeof(InputTwoColumnsUC);
    public void FocusOnMainElement()
    {
        txt1.Focus();
    }
    public TextBox txtFirst
    {
        get
        {
            return txt1;
        }
    }
    public TextBox txtSecond
    {
        get
        {
            return txt2;
        }
    }
    const int rowsCount = 2;
    List<TextBox> checkForContent = new List<TextBox>();
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
    public InputTwoColumnsUC(int neededRows) : this()
    {
        if (neededRows > rowsCount)
        {
            ThrowEx.BadMappedXaml("InputTwoColumnsUC", Translate.FromKey(XlfKeys.ItNeedsMoreRowsThanItExists));
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
                WpfLogger.Error(Translate.FromKey(XlfKeys.AllOfTheInputsMustBeFilled));
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
    public void Init(string textFirst, string textSecond)
    {
        tb1.Text = textFirst;
        tb2.Text = textSecond;
    }
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
    public string Title => Translate.FromKey(XlfKeys.InputTwoColumns);
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
    public int CountOfHandlersChangeDialogResult()
    {
        return RuntimeHelper.GetInvocationList(ChangeDialogResult).Count;
    }
    public void AttachChangeDialogResult(VoidBoolNullable handler, bool throwException = true)
    {
        RuntimeHelper.AttachChangeDialogResult(this, handler, throwException);
    }
    public void Init()
    {
    }
    public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
    {
    }
}
