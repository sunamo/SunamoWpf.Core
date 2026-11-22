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

    /// <summary>
    /// Initializes a new instance of the sunamo password box class.
    /// </summary>
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

    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="noMargin">The no margin.</param>
    public void Init(bool noMargin)
    {
        btnShowPassword.Content = "HidePassword";

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

    /// <summary>
    /// The password.
    /// </summary>
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

    /// <summary>
    /// The brush of border.
    /// </summary>
    public Brush BrushOfBorder
    {
        get; set;
    } = Brushes.Yellow;

    /// <summary>
    /// The show txt show password.
    /// </summary>
    public bool ShowTxtShowPassword
    {
        set
        {
            var visibility = VisibilityBooleanConverter.FromBool(value);


            spShowPassword.Visibility = visibility;
        }
    }

    /// <summary>
    /// The overall width.
    /// </summary>
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
            btnShowPassword.Content = "HidePassword";
        }
        else
        {
            btnShowPassword.Content = "ShowPassword";
        }
        txtShowPassword.Visibility = visibility;
    }

    /// <summary>
    /// On size changed.
    /// </summary>
    /// <param name="size">The size.</param>
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
