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
            TextBlock tb = null;
            TextBox txt = null;
            Visibility visible = Visibility.Visible;
            for (int i = 1; i < rowsCount + 1; i++)
            {
                tb = FrameworkElementHelper.FindName<TextBlock>(this, ControlNames.tb, i);
                txt = FrameworkElementHelper.FindName<TextBox>(this, ControlNames.txt, i);
                if (visible == Visibility.Visible)
                {
                    checkForContent.Add(txt);
                }
                tb.Visibility = txt.Visibility = visible;
                if (i == neededRows)
                {
                    visible = Visibility.Collapsed;
                }
            }
        }
    }
    private void DialogButtons_ChangeDialogResult(bool? b)
    {
        if (b.HasValue)
        {
            if (!b.Value)
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
        ABT<string, string> d = (ABT<string, string>)input;
        txtFirst.Text = d.A;
        txtSecond.Text = d.B;
        // Cant be, window must be already showned as dialog
        //DialogResult = true;
    }
    //
    public int CountOfHandlersChangeDialogResult()
    {
        return RuntimeHelper.GetInvocationList(ChangeDialogResult).Count;
    }
    public void AttachChangeDialogResult(VoidBoolNullable a, bool throwException = true)
    {
        RuntimeHelper.AttachChangeDialogResult(this, a, throwException);
    }
    public void Init()
    {
    }
    public void uc_Loaded(object sender, RoutedEventArgs e)
    {
    }
}
