#define ASYNC
namespace SunamoWpf.Controls.Input;

/// <summary>
/// Interaction logic for SunamoPasswordBox.xaml
/// </summary>
public partial class SunamoPasswordBox : UserControl, IUserControlWithSizeChange
{
    List<PasswordBox> pwbc;
    List<Button> btnc;
    List<TextBlock> tbc;

    public SunamoPasswordBox()
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

        SizeChanged += SunamoPasswordBox_SizeChanged;

    }

    bool noMargin = false;

    public void Init(bool noMargin)
    {
        btnShowPassword.Content = Translate.FromKey(XlfKeys.HidePassword);

        this.noMargin = noMargin;
        if (noMargin)
        {

        }
        else
        {
            // only txtShowPassword has in xaml 5px
            ResourceDictionaryStyles.Margin10(pwbc);
            ResourceDictionaryStyles.Margin10(btnc);
            ResourceDictionaryStyles.Margin10(tbc);
        }
    }

    public string Password
    {
        get
        {
            return txtPassword.Password;
        }
        set
        {
            txtPassword.Password = value;
        }
    }

    private void SunamoPasswordBox_SizeChanged(object sender, SizeChangedEventArgs eventArgs)
    {

    }

    public Brush BrushOfBorder
    {
        get; set;
    } = Brushes.Yellow;

    public bool ShowTxtShowPassword
    {
        set
        {
            var visibility = VisibilityBooleanConverter.FromBool(value);


            spShowPassword.Visibility = visibility;
        }
    }

    public double OverallWidth
    {
        set
        {
            txtPassword.Width = value;
        }
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs eventArgs)
    {
        var passwordBox = (PasswordBox)eventArgs.Source;
        if (passwordBox != null)
        {
            System.Diagnostics.Debug.WriteLine(passwordBox.Password);
            var textBox = passwordBox.Template.FindName("RevealedPassword", passwordBox) as TextBox;
            if (textBox != null)
            {
                textBox.Text = passwordBox.Password;
            }
        }

        txtShowPassword.Text = txtPassword.Password;
    }

    private void Button_Click(object sender, RoutedEventArgs eventArgs)
    {
        var visible = !VisibilityBooleanConverter.ToBool(txtShowPassword.Visibility);
        var visibility = VisibilityBooleanConverter.FromBool(visible);
        if (visibility == Visibility.Collapsed)
        {
            visibility = Visibility.Hidden;
        }
        if (visible)
        {
            btnShowPassword.Content = Translate.FromKey(XlfKeys.HidePassword);
        }
        else
        {
            btnShowPassword.Content = Translate.FromKey(XlfKeys.ShowPassword);
        }
        txtShowPassword.Visibility = visibility;
    }

    public void OnSizeChanged(DesktopSize size)
    {
        if (noMargin)
        {
            txtPassword.Width = spShowPassword.Width = size.Width;
        }
        else
        {
            txtPassword.Width = size.Width - 2 * 5;
        }
    }
}
