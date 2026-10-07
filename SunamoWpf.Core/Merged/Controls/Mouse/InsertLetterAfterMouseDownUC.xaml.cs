#define ASYNC
namespace SunamoWpf.Controls.Mouse;

public partial class InsertLetterAfterMouseDownUC : UserControl, IControlWithResultWpf, IShowSearchResults
{
    public string ToInsert = "\\";
    public void FocusOnMainElement()
    {
    }
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
    public event VoidBoolNullable ChangeDialogResult;
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
    public TextBoxStateWpf state = new TextBoxStateWpf();
    public void SetTbSearchedResult(int actual, int count)
    {
        state.textSearchedResult = $"{actual}/{count}";
        SetTextBoxState();
    }
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
