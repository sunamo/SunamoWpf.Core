#define ASYNC
namespace SunamoWpf.Controls.Input;

public partial class SelectOneValue : UserControl, IControlWithResultWpf, IUserControl
{
    /// <summary>
    /// The cb entered helper.
    /// </summary>
    public ComboBoxHelper<string> cbEnteredHelper = null;
    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        cbEntered.Focus();
    }
    /// <summary>
    /// A2 can be null
    /// </summary>
    /// <param name="allowCustomEntry"></param>
    /// <param name="whatEnter"></param>
    /// <param name="toMakeNameInTWithName"></param>
    /// <param name="items"></param>
    public SelectOneValue(bool allowCustomEntry, string whatEnter, Func<object, string> toMakeNameInTWithName, params object[] items)
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
        Init(whatEnter);
    }
    /// <summary>
    /// The selected item.
    /// </summary>
    public string SelectedItem
    {
        get
        {
            return cbEntered.Text;
        }
    }
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="whatEnter">The what enter.</param>
    public void Init(string whatEnter)
    {
        Init(false, whatEnter, null, null);
    }
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="allowCustomEntry">The allow custom entry.</param>
    /// <param name="whatEnter">The what enter.</param>
    /// <param name="toMakeNameInTWithName">The to make name in t with name.</param>
    /// <param name="items">The items.</param>
    public void Init(bool allowCustomEntry, string whatEnter, Func<object, string> toMakeNameInTWithName, params object[] items)
    {
        cbEnteredHelper = new ComboBoxHelper<string>(cbEntered);
        cbEntered.IsEditable = allowCustomEntry;
        if (toMakeNameInTWithName != null /*&& items != null*/)
        {
            cbEnteredHelper.AddValuesOfArrayAsItems(toMakeNameInTWithName, null, items);
        }
        cbEntered.SelectionChanged += CbEntered_Selected;
        tbWhatEnter.Text = "EnterOrSelect" + " " + whatEnter;
    }
    private void btnEnter_Click_1(object sender, RoutedEventArgs eventArgs)
    {
        if (AfterEnteredValue(cbEntered))
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
    /// Very stupid, if was set ParentWIndow.DialogResult was set here, then "'DialogResult can be set only after Window is created and shown as dialog.'" occured
    /// Right approach is call here Finished which has registered WindowWithUserControl, which will set DialogResult itself
    /// </summary>
    public object ParentWindow { set { } }
    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => "SelectOneValue";
    private bool AfterEnteredValue(ComboBox cbEntered)
    {
        cbEntered.Text = SelectedItem.Trim();
        if (cbEntered.Text != "")
        {
            cbEntered.BorderThickness = new Thickness(0);
            return true;
        }
        cbEntered.BorderThickness = new Thickness(2);
        cbEntered.BorderBrush = new SolidColorBrush(Colors.Red);
        return false;
    }
    private void cbEntered_KeyDown_1(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.Key == Key.Enter)
        {
        }
    }
    private void EnableBtn()
    {
        if (AfterEnteredValue(cbEntered))
        {
            if (cbEnteredHelper.Selected)
            {
                btnEnter.IsEnabled = true;
            }
            else
            {
                btnEnter.IsEnabled = false;
            }
        }
    }
    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Accept(object input)
    {
        cbEntered.Text = input.ToString();
        ButtonHelperDesktop2.PerformClick(btnEnter);
        // Cant be, window must be already showned as dialog
        //DialogResult = true;
    }
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
    private void CbEntered_Selected(object sender, RoutedEventArgs eventArgs)
    {
        EnableBtn();
    }
    static Type type = typeof(SelectOneValue);
    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
    }
}
