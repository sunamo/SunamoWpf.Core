#define ASYNC


namespace SunamoWpf.Controls.Input;

/// <summary>
/// Interaction logic for LoginDialog.xaml
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public partial class LoginDialog : UserControl, IUserControlWithSizeChange
{
    #region Rewrite to pure cs. With xaml is often problems without building
    static Type type = typeof(Type);
    /// <summary>
    /// The tbc.
    /// </summary>
    public List<TextBlock> tbc;
    /// <summary>
    /// The chbc.
    /// </summary>
    public List<CheckBox> chbc;
    /// <summary>
    /// The txtc.
    /// </summary>
    public List<TextBox> txtc;
    /// <summary>
    /// The btnc.
    /// </summary>
    public List<Button> btnc;
    /// <summary>
    /// The spbc.
    /// </summary>
    public List<SunamoPasswordBox> spbc;
    /// <summary>
    /// The gridc.
    /// </summary>
    public List<Grid> gridc;
    //public List<PasswordBox> pwbc;
    private void LoginDialog_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        txtHeslo.Init(true);
        SizeChanged += LoginDialog_SizeChanged;
        tbc = CAG.ToList<TextBlock>(tbLogin, tbPw);
        chbc = CAG.ToList<CheckBox>(chbAutoLogin, chbRememberLogin);
        txtc = CAG.ToList<TextBox>(txtLogin);
        btnc = CAG.ToList<Button>(btnForgetLoginAndPassword, btnForgetPassword, btnLogin);
        // txtHeslo cant be, is around gridSpb
        // is empty - cant processed
        //spbc = CAG.ToList<SunamoPasswordBox>();
        gridc = CAG.ToList<Grid>(gridSpb);
        //pwbc = CAG.ToList<PasswordBox>(txtHeslo);
        ResourceDictionaryStyles.Padding10(tbc);
        ResourceDictionaryStyles.Margin10(chbc);
        ResourceDictionaryStyles.Margin10(txtc);
        ResourceDictionaryStyles.Margin10(btnc);
        //ResourceDictionaryStyles.Margin10(spbc);
        ResourceDictionaryStyles.Margin10(gridc);
        txtHeslo.txtPassword.HorizontalAlignment = HorizontalAlignment.Stretch;
        txtHeslo.spShowPassword.HorizontalAlignment = HorizontalAlignment.Stretch;
        //ResourceDictionaryStyles.Margin(10,pwbc);
    }
    private void LoginDialog_SizeChanged(object sender, SizeChangedEventArgs eventArgs)
    {
        // All in OnSizeChanged
    }
    /// <summary>
    /// The login.
    /// </summary>
    public string Login
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
            return txtHeslo.Password;
        }
    }
    string title = null;
    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => title;
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
    /// The login enigma.
    /// </summary>
    public string LoginEnigma;
    /// <summary>
    /// The pw enigma.
    /// </summary>
    public string PwEnigma;
    StorageApplicationData storageApplicationData = StorageApplicationData.NoWhere;
    const string h = "h";
    const string l = "l";
    const string s = "s";
    string iniCredSection = "Cred";
    /// <summary>
    /// A1 = RandomHelper.RandomString(10)
    /// Set also CryptDelegates from shared.unsafe
    ///
    /// This must be private
    /// </summary>
    private LoginDialog(string salt)
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
        chbAutoLogin.Checked += chbAutoLogin_Checked;
        chbRememberLogin.Unchecked += chbRememberLogin_Unchecked;
        tbLogin.Text = "Login" + ": ";
        tbPw.Text = "Password" + ": ";
        chbRememberLogin.Content = "RememberLogin";
        chbAutoLogin.Content = "AutoLogin";
        btnLogin.Content = "Login";
        btnForgetPassword.Content = "ForgetPassword";
        btnForgetLoginAndPassword.Content = "Forget login and password";
        Loaded += LoginDialog_Loaded;
    }
    void chbRememberLogin_Unchecked(object sender, RoutedEventArgs eventArgs)
    {
        chbAutoLogin.IsChecked = false;
    }
    void chbAutoLogin_Checked(object sender, RoutedEventArgs eventArgs)
    {
        chbRememberLogin.IsChecked = true;
    }
    /// <summary>
    /// The crypt delegates.
    /// </summary>
    public CryptDelegatesWpf cryptDelegates = null;
    /// <summary>
    /// The change dialog result.
    /// </summary>
    public event VoidBoolNullable ChangeDialogResult;
    string salt = null;
    string pPw; string pSalt; string pLogin;
    /// <summary>
    /// Set also CryptDelegates from shared.unsafe
    /// </summary>
    /// <param name="salt"></param>
    /// <param name="storageApplicationData"></param>
    public LoginDialog(string salt, StorageApplicationData storageApplicationData, CryptDelegatesWpf cryptDelegatesWpf)
        : this(salt)
    {
        this.salt = salt;
        this.storageApplicationData = storageApplicationData;
        cryptDelegates = cryptDelegatesWpf;
    }
        /// <summary>
        /// Init.
        /// </summary>
        /// <param name="pPw">The p pw.</param>
        /// <param name="pSalt">The p salt.</param>
        /// <param name="pLogin">The p login.</param>
    public
#if ASYNC
async Task
#else
void
#endif
        Init(string pPw, string pSalt, string pLogin)
    {
        this.pLogin = pLogin;
        this.pPw = pPw;
        this.pSalt = pSalt;
        title = "EnterLoginCredentials";
        if (storageApplicationData == StorageApplicationData.Registry)
        {
            string salt2 = RA.ReturnValueString(s);
            if (salt2 == "")
            {
                RA.WriteToKeyString(s, salt);
                salt2 = salt;
            }
            string encryptedH = RA.ReturnValueString(h);
            if (encryptedH != "")
            {
                this.txtHeslo.Password = cryptDelegates.DecryptString(salt2, encryptedH);
            }
            this.txtLogin.Text = RA.ReturnValueString(l);
        }
        else if (storageApplicationData == StorageApplicationData.TextFile)
        {
            //IniFile ini = IniFile.InStartupPath();
            string salt2 =
#if ASYNC
await
#endif
TF.ReadAllText(pSalt);
            if (salt2 == "")
            {
#if ASYNC
                await
#endif
                TF.WriteAllText(pSalt, salt);
                salt2 = salt;
            }
            string encryptedH =
#if ASYNC
await
#endif
TF.ReadAllText(pPw);
            if (encryptedH != "")
            {
                this.txtHeslo.Password = cryptDelegates.DecryptString(salt2, encryptedH);
            }
            this.txtLogin.Text =
#if ASYNC
await
#endif
TF.ReadAllText(pLogin);
        }
        else if (storageApplicationData == StorageApplicationData.Config)
        {
            ThrowExceptionConfigNotSupported();
        }
        else if (storageApplicationData == StorageApplicationData.NoWhere)
        {
            // Nedělej nic, uživatel si nepřeje ukládat credentials
        }
        else
        {
            ThrowEx.NotImplementedCase(storageApplicationData);
        }
        if (txtLogin.Text != "")
        {
            this.chbRememberLogin.IsChecked = txtLogin.Text != "";
            this.chbAutoLogin.IsChecked = txtHeslo.Password != "";
        }
        else
        {
            this.chbRememberLogin.IsChecked = false;
            this.chbAutoLogin.IsChecked = false;
        }
    }
    private static void ThrowExceptionConfigNotSupported()
    {
        ThrowEx.Custom("Saving settings to app config or web config is not yet supported");
    }
    private void btnLogin_Click(object sender, RoutedEventArgs eventArgs)
    {
        //btnLogin_ClickAsync(null, null);
    }
    private
#if ASYNC
async Task
#else
void
#endif
btnLogin_ClickAsync(object sender, RoutedEventArgs eventArgs)
    {
        if (storageApplicationData == StorageApplicationData.Registry)
        {
            if ((bool)chbRememberLogin.IsChecked)
            {
                RA.WriteToKeyString(l, this.txtLogin.Text);
                if ((bool)this.chbAutoLogin.IsChecked)
                {
                    RA.WriteToKeyString(h, cryptDelegates.EncryptString(RA.ReturnValueString(s), this.txtHeslo.Password));
                }
                else
                {
                    RA.WriteToKeyString(h, "");
                }
            }
            else
            {
                RA.WriteToKeyString(h, "");
                RA.WriteToKeyString(l, "");
            }
        }
        else if (storageApplicationData == StorageApplicationData.TextFile)
        {
            if ((bool)chbRememberLogin.IsChecked)
            {
#if ASYNC
                await
#endif
                TF.WriteAllText(pLogin, this.txtLogin.Text);
                if ((bool)this.chbAutoLogin.IsChecked)
                {
#if ASYNC
                    await
#endif
                    TF.WriteAllText(pPw, cryptDelegates.EncryptString(
#if ASYNC
await
#endif
TF.ReadAllText(pSalt), this.txtHeslo.Password));
                }
                else
                {
#if ASYNC
                    await
#endif
                    TF.WriteAllText(pPw, "");
                }
            }
            else
            {
#if ASYNC
                await
#endif
                TF.WriteAllText(pLogin, "");
#if ASYNC
                await
#endif
                TF.WriteAllText(pPw, "");
            }
        }
        else if (storageApplicationData == StorageApplicationData.Config)
        {
            ThrowExceptionConfigNotSupported();
        }
        else //if (storageApplicationData != StorageApplicationData.NoWhere)
        {
        }
        DialogResult = true;
    }
    private void btnForgetLoginAndPassword_Click(object sender, RoutedEventArgs eventArgs)
    {
        //btnForgetLoginAndPassword_ClickAsync(null, null);
    }
    private
#if ASYNC
async Task
#else
void
#endif
btnForgetLoginAndPassword_ClickAsync(object sender, RoutedEventArgs eventArgs)
    {
        txtLogin.Text = "";
        txtHeslo.Password = "";
        if (storageApplicationData == StorageApplicationData.Config)
        {
            ThrowExceptionConfigNotSupported();
        }
        else if (storageApplicationData == StorageApplicationData.Registry)
        {
            RA.WriteToKeyString(l, "");
            RA.WriteToKeyString(h, "");
        }
        else if (storageApplicationData == StorageApplicationData.NoWhere)
        {
            // Nedělej nic, data nebyly nikde uloženy
        }
        else if (storageApplicationData == StorageApplicationData.TextFile)
        {
#if ASYNC
            await
#endif
            TF.WriteAllText(pLogin, "");
#if ASYNC
            await
#endif
            TF.WriteAllText(pPw, "");
        }
        else
        {
            ThrowEx.NotImplementedCase(storageApplicationData);
        }
    }
    private void btnForgetPassword_Click(object sender, RoutedEventArgs eventArgs)
    {
        //btnForgetPassword_ClickAsync(null, null);
    }
    private
#if ASYNC
async Task
#else
void
#endif
btnForgetPassword_ClickAsync(object sender, RoutedEventArgs eventArgs)
    {
        txtHeslo.Password = "";
        if (storageApplicationData == StorageApplicationData.Config)
        {
            ThrowExceptionConfigNotSupported();
        }
        else if (storageApplicationData == StorageApplicationData.Registry)
        {
            RA.WriteToKeyString(h, "");
        }
        else if (storageApplicationData == StorageApplicationData.TextFile)
        {
#if ASYNC
            await
#endif
            TF.WriteAllText(pPw, "");
        }
        else if (storageApplicationData == StorageApplicationData.NoWhere)
        {
            // Nedělej nic, data nebyly nikde uloženy
        }
        else
        {
            ThrowEx.NotImplementedCase(storageApplicationData);
        }
    }
    //public void Accept(object input)
    //{
    //    ThrowEx.NotImplementedMethod();
    //}
    /// <summary>
    /// Focus on main element.
    /// </summary>
    public void FocusOnMainElement()
    {
        // Nemůžu tu nastavovat, FocusOnMainElement se volá automaticky, tím pádem se nastaví žluté obtažení ale nefunguje kurzor. Když kliknu do txtPassword mají zvýraznění oba 2
        //txtLogin.Focus();
    }
    /// <summary>
    /// On size changed.
    /// </summary>
    /// <param name="size">The size.</param>
    public void OnSizeChanged(DesktopSize size)
    {
        txtHeslo.OnSizeChanged(new DesktopSize(size.Width, size.Height));
    }
    #endregion
}
