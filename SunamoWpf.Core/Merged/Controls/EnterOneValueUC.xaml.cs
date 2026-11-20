#define ASYNC
namespace SunamoWpf.Controls.Input;

public partial class EnterOneValueUC : UserControl, IControlWithResultWpf, IUserControlWithSuMenuItemsList, IControlWithResultDebugWpf
{
    /// <summary>
    /// The validator before adding.
    /// </summary>
    public Func<string, bool> ValidatorBeforeAdding = null;
    /// <summary>
    /// The validator before adding message.
    /// </summary>
    public string ValidatorBeforeAddingMessage = null;
    static Type type = typeof(EnterOneValueUC);
    /// <summary>
    /// The validate data.
    /// </summary>
    public ValidateDataWpf validateData = null;
    #region ctor
    /// <summary>
    /// Has button so dialogButtons is not needed to add
    /// </summary>
    public EnterOneValueUC()
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
        dynLayout = new DynLayout(gridGrowable);
        fwElemements = CAG.ToList<FrameworkElement>(txtEnteredText);
        Loaded += uc_Loaded;
    }
    /// <summary>
    /// Initializes a new instance of the enter one value UC class.
    /// </summary>
    /// <param name="whatEnter">The what enter.</param>
    /// <param name="size">The size.</param>
    public EnterOneValueUC(string whatEnter, Size size) : this()
    {
        Init(whatEnter);
        if (size != Size.Empty)
        {
            txtEnteredText.Width = size.Width;
            txtEnteredText.Height = size.Height;
        }
    }
    /// <summary>
    /// BY default use args-less ctor and then Init
    /// </summary>
    /// <param name="whatEnter"></param>
    public EnterOneValueUC(string whatEnter) : this()
    {
        Init(whatEnter);
        txtEnteredText.AcceptsReturn = true;
        Loaded += EnterOneValueUC_Loaded;
    }
    #endregion
    /// <summary>
    /// The is multiline.
    /// </summary>
    public bool IsMultiline
    {
        set
        {
            if (value)
            {
                txtEnteredText.AcceptsReturn = true;
                txtEnteredText.Height = txtEnteredText.Height * 5;
            }
            else
            {
                txtEnteredText.AcceptsReturn = false;
                txtEnteredText.Height /= 5;
            }
        }
    }
    /// <summary>
    /// Enter one value UC loaded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public void EnterOneValueUC_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        PrintColumnsRows(gridGrowable);
        PrintColumnsRows(grid2);
    }
    private void PrintColumnsRows(Grid grid2)
    {
#if DEBUG
        //////////DebugLogger.Instance.WriteLine(grid2.ColumnDefinitions.Count + "x" + grid2.RowDefinitions.Count);
#endif
    }
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="whatEnter">The what enter.</param>
    public void Init(string whatEnter)
    {
        tbWhatEnter.Text = "ToEnter" + " " + whatEnter + " " + "andPressEnter" + ".";
        btnEnter.Content = "Enter";
    }
    /// <summary>
    /// TextBlock.Text is take from Tag, which can be TWithNameT<object>
    /// Tag can be TWithNameT<object> or any object and its value is set to TextBlock
    /// </summary>
    /// <param name="uie"></param>
    public void Init(IList<FrameworkElement> uie, GridSize gridSize = GridSize.GetAutoSize)
    {
        //gridGrowable.
        txtEnteredText.Visibility = Visibility.Collapsed;
        //txtEnteredText.Parent.Chi
        fwElemements = uie.ToList();
        if (gridSize == GridSize.GetAutoSize)
        {
            GridHelper.GetAutoSize(gridGrowable, 2, uie.Count());
        }
        else if (gridSize == GridSize.Mine)
        {
            ThrowEx.NotImplementedCase(gridSize);
        }
        else if (gridSize == GridSize.XamlDefined)
        {
            // is already in xaml
            GridHelper.GetAutoSize(gridGrowable, 0, uie.Count());
        }
        int index = 0;
        foreach (var item in uie)
        {
            string name = null;
            name = ExtractName(item);
            AddControl(index, name, item);
            index++;
        }
    }
    private static string ExtractName(FrameworkElement item)
    {
        string name;
        if (item.Tag is TWithNameTWpf<object>)
        {
            var tagged = (TWithNameTWpf<object>)item.Tag;
            name = tagged.name;
        }
        else
        {
            name = item.Tag.ToString();
        }
        return name;
    }
    private void btnEnter_Click_1(object sender, RoutedEventArgs eventArgs)
    {
        if (AfterEnteredValue(fwElemements))
        {
            DialogResult = true;
        }
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
    public string Title => "EnteringData";
    /// <summary>
    /// Get content by tag.
    /// </summary>
    /// <param name="tag">The tag.</param>
    /// <returns>The get content by tag result.</returns>
    public object GetContentByTag(object tag)
    {
        return dynLayout.GetContentByTag(tag);
    }
    /// <summary>
    /// Add control.
    /// </summary>
    /// <param name="row">The row.</param>
    /// <param name="name">The name.</param>
    /// <param name="control">The control.</param>
    public void AddControl(int row, string name, FrameworkElement control)
    {
        dynLayout.AddControl(row, name, control);
    }
    private bool AfterEnteredValue(List<FrameworkElement> txtEnteredText)
    {
        bool? previousValidate = true;
        bool allOk = true;
        // in txtEnteredText is only txtEnteredText
        foreach (var item in txtEnteredText)
        {
            // Always set to true
            // Set up previous validate state
            item.SetValidated(previousValidate.Value);
            // 1. must ci
            validateData = new ValidateDataWpf();
            // Coz there is only txtEnteredText, I can set up it here
            // 2. must assign
            validateData.validateMethod = ValidatorBeforeAdding;
            validateData.messageWhenValidateMethodFails = ValidatorBeforeAddingMessage;
            previousValidate = item.Validate2(ExtractName(item), ref validateData);
            if (previousValidate.HasValue)
            {
                if (!previousValidate.Value)
                {
                    if (RH.IsOrIsDeriveFromBaseClass(item.GetType(), TypesControls.tControl))
                    {
                        var control = (Control)item;
                        control.BorderThickness = new Thickness(2);
                        control.BorderBrush = new SolidColorBrush(Colors.Red);
                        if (validateData != null)
                        {
                            if (!string.IsNullOrEmpty(validateData.messageToReallyShow))
                            {
                                tbHint.Text = validateData.messageToReallyShow;
                            }
                        }
                        allOk = false;
                    }
                }
            }
            else
            {
                allOk = false;
                ThrowEx.Custom("Not implemented validate for control" + " " + item.GetType().FullName);
            }
        }
        //txtEnteredText.Text = txtEnteredText.Text.Trim();
        //if (txtEnteredText.Text != "")
        //{
        //    return true;
        //}
        if (allOk)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// The fw elemements.
    /// </summary>
    public List<FrameworkElement> fwElemements
    {
        get
        {
            return dynLayout.fwElements;
        }
        set
        {
            dynLayout.fwElements = value;
        }
    }
    /// <summary>
    /// The this int.
    /// </summary>
    public object this[int index]
    {
        get
        {
            return fwElemements[index].GetContent();
        }
    }
    /// <summary>
    /// The dyn layout.
    /// </summary>
    public DynLayout dynLayout = null;
    private void txtEnteredText_KeyDown_1(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.Key == Key.Enter)
        {
            if (AfterEnteredValue(fwElemements))
            {
                DialogResult = true;
            }
        }
    }
    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Accept(object input)
    {
        txtEnteredText.Text = input.ToString();
        ButtonHelperDesktop2.PerformClick(btnEnter);
        // Cant be, window must be already showned as dialog
        //DialogResult = true;
    }
    /// <summary>
    /// The su su menu items.
    /// </summary>
    public List<SuMenuItem> suSuMenuItems = new List<SuMenuItem>();
    //public TextBox txtEnteredText => new TextBox();
    /// <summary>
    /// Su menu items.
    /// </summary>
    /// <returns>The su menu items result.</returns>
    public List<SuMenuItem> SuMenuItems()
    {
        return suSuMenuItems;
    }
    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
    }
    /// <summary>
    /// Count of handlers change dialog result.
    /// </summary>
    /// <returns>The count of handlers change dialog result result.</returns>
    public int CountOfHandlersChangeDialogResult()
    {
        var invocationList = RuntimeHelper.GetInvocationList(ChangeDialogResult);
        return invocationList.Count;
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
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        txtEnteredText.Focus();
    }
    /// <summary>
    /// Uc loaded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        //ThrowEx.NotImplementedMethod(Exc.GetStackTrace(),type, Exceptions.CallingMethod());
    }
    /// <summary>
    /// Remove which have no item.
    /// </summary>
    public void RemoveWhichHaveNoItem()
    {
    }
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
}
//    public List<SuMenuItem> SuMenuItems = new List<SuMenuItem>();
//    public TextBox txtEnteredText = new TextBox();
//    private string v = string.Empty;
//    public EnterOneValueUC()
//    {
//    }
//    public EnterOneValueUC(string v)
//    {
//        this.v = v;
//    }
//    public bool? DialogResult { set { } }
//    public string Title => "";
//    public event VoidBoolNullable ChangeDialogResult;
//    public void Accept(object input)
//    {
//    }
//    public void AttachChangeDialogResult(VoidBoolNullable a, bool throwException = true)
//    {
//    }
//    public int CountOfHandlersChangeDialogResult()
//    {
//        return 0;
//    }
//    public void FocusOnMainElement()
//    {
//    }
//    public void Init(List<FrameworkElement> fwElements)
//    {
//    }
//    public List<SuMenuItem> SuMenuItems()
//    {
//        return new List<SuMenuItem>();
//    }
//    public void Init()
//    {
//    }
//    public void Init(string whatEnter)
//    {
//
//    }
//    public List<FrameworkElement> fwElemements = new List<FrameworkElement>();
//    public string ValidatorBeforeAddingMessage = string.Empty;
//    public bool IsMultiline { get; set; } = true;
//    public Func<string, bool> ValidatorBeforeAdding { get; set; }
//    public object this[int i]
//    {
//        get
//        {
//            return new Control();
//        }
//    }
//}
