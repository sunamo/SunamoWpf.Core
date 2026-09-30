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
    private void DialogButtons_ChangeDialogResult(bool? b)
    {
        ChangeDialogResult(b);
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
    private void Txt_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Right)
        {
            insertNow = false;
        }
        else if (e.ChangedButton == MouseButton.Left)
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
    public void SetTextBoxState(string s = null)
    {
        if (s == null)
        {
            s = state.textSearchedResult;
        }
        tbState.Text = s;
    }
    private void BtnOk_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
    Key lastKey = Key.Enter;
    private void Txt_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != lastKey)
        {
            if (e.Key == Key.Enter)
            {
                lastKey = e.Key;
                DialogResult = true;
            }
        }
    }
}
