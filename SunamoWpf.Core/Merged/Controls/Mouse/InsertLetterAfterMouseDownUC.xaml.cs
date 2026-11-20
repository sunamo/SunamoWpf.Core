#define ASYNC
namespace SunamoWpf.Controls.Mouse;

public partial class InsertLetterAfterMouseDownUC : UserControl, IControlWithResultWpf, IShowSearchResults
{
    /// <summary>
    /// The to insert.
    /// </summary>
    public string ToInsert = "\\";
    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
    }
    /// <summary>
    /// The dialog result.
    /// </summary>
    public bool? DialogResult
    {
        set
        {
            if (value.HasValue && value.Value)
            {
                Data.Inserted = txt.Text;
                ChangeDialogResult(value);
            }
        }
    }
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
    /// <summary>
    /// Initializes a new instance of the insert letter after mouse down UC class.
    /// </summary>
    public InsertLetterAfterMouseDownUC()
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
        //txt.KeyDown += Txt_KeyDown;
    }
    private void DialogButtons_ChangeDialogResult(bool? result)
    {
        ChangeDialogResult(result);
    }
    InsertLetterAfterMouseDownData Data
    {
        get
        {
            return (InsertLetterAfterMouseDownData)Tag;
        }
    }
    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Accept(object input)
    {
        txt.Text = input.ToString();
        ChangeDialogResult(true);
    }
    bool insertNow
    {
        get
        {
            return BTS.GetValueOfNullable(chbInsert.IsChecked);
        }
        set
        {
            chbInsert.IsChecked = value;
        }
    }
    private void Txt_PreviewMouseUp(object sender, MouseButtonEventArgs eventArgs)
    {
        if (eventArgs.ChangedButton == MouseButton.Right)
        {
            insertNow = false;
        }
        else if (eventArgs.ChangedButton == MouseButton.Left)
        {
            if (insertNow)
            {
                txt.Text = txt.Text.Insert(txt.SelectionStart, ToInsert);
            }
        }
    }
    /// <summary>
    /// The state.
    /// </summary>
    public TextBoxStateWpf state = new TextBoxStateWpf();
    /// <summary>
    /// Set tb searched result.
    /// </summary>
    /// <param name="actual">The actual.</param>
    /// <param name="count">The count.</param>
    public void SetTbSearchedResult(int actual, int count)
    {
        state.textSearchedResult = $"{actual}/{count}";
        SetTextBoxState();
    }
    /// <summary>
    /// Set text box state.
    /// </summary>
    /// <param name="text">The text.</param>
    public void SetTextBoxState(string text = null)
    {
        if (text == null)
        {
            text = state.textSearchedResult;
        }
        tbState.Text = text;
    }
    private void BtnOk_Click(object sender, RoutedEventArgs eventArgs)
    {
        DialogResult = true;
    }
    Key lastKey = Key.Enter;
    private void Txt_KeyDown(object sender, KeyEventArgs eventArgs)
    {
        if (eventArgs.Key != lastKey)
        {
            if (eventArgs.Key == Key.Enter)
            {
                lastKey = eventArgs.Key;
                DialogResult = true;
            }
        }
    }
}
