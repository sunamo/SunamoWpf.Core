#define ASYNC
namespace SunamoWpf;

public partial class LoginUc : UserControl//, IControlWithResult, IKeysHandler
{
    #region MyRegion
    bool publicSaveLogic = false;
    const string h = "h";
    const string l = "l";
    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        btnLetsLogin.Focus();
    }
    /// <summary>
    /// Initializes a new instance of the login uc class.
    /// </summary>
    public LoginUc()
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
    /// A1 je vhodné tehdy když například pouštím python skripty, ve kterých nemůžu ověřit zda se mi podařilo nalogovat
    /// </summary>
    /// <param name="publicSaveLogic"></param>
    public LoginUc(bool publicSaveLogic)
        : this()
    {
        this.publicSaveLogic = publicSaveLogic;
        if (publicSaveLogic)
        {
            this.txtHeslo.Text = RA.ReturnValueString(h);
            this.txtLogin.Text = RA.ReturnValueString(l);
            this.chbUlozHeslo.IsChecked = this.txtHeslo.Text != "";
        }
    }
    private void btnLetsLogin_Click(object sender, RoutedEventArgs eventArgs)
    {
        if (publicSaveLogic)
        {
            RA.WriteToKeyString(h, "");
            RA.WriteToKeyString(l, this.txtLogin.Text);
            if (this.chbUlozHeslo.IsChecked.Value)
            {
                RA.WriteToKeyString(h, this.txtHeslo.Text);
            }
            if (txtLogin.Text.Trim() != "" && txtHeslo.Text.Trim() != "")
            {
                DialogResult = true;
            }
            else
            {
                ChangeDialogResult(false);
            }
        }
        else
        {
            ChangeDialogResult(true);
        }
    }
    private void btnCancel_Click(object sender, RoutedEventArgs eventArgs)
    {
        ChangeDialogResult(false);
    }
    /// <summary>
    /// Have logined data.
    /// </summary>
    /// <returns>The have logined data result.</returns>
    public bool HaveLoginedData()
    {
        string firstValue = RA.ReturnValueString(h);
        string secondValue = RA.ReturnValueString(l);
        return firstValue != "" && secondValue != "";
    }
    /// <summary>
    /// A1 = LoginData
    /// </summary>
    /// <param name="input"></param>
    public void Accept(object input)
    {
        LoginData loginData = (LoginData)input;
        txtLogin.Text = loginData.Login;
        txtHeslo.Text = loginData.Pw;
        // Cant be, window must be already showned as dialog
        //DialogResult = true;
    }
    /// <summary>
    /// Handle key.
    /// </summary>
    /// <param name="e*/">The e.</param>
    /// <returns>The handle key result.</returns>
    public bool HandleKey(/*KeyEventArgs e*/)
    {
        return false;
    }
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
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
    /// The uc size.
    /// </summary>
    public Size UcSize
    {
        get { return this.DesiredSize; }
    }
    /// <summary>
    /// The login.
    /// </summary>
    public String Login
    {
        get
        {
            return txtLogin.Text;
        }
    }
    /// <summary>
    /// The heslo.
    /// </summary>
    public string Heslo
    {
        get
        {
            return txtHeslo.Text;
        }
    }
    /// <summary>
    /// Gets the accept button.
    /// </summary>
    public ButtonBase AcceptButton => btnLetsLogin;
    #endregion
}
