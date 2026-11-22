#define ASYNC
namespace SunamoWpf;

public sealed partial class ErrorListing : UserControl
{
    #region Rewrite to pure cs. With xaml is often problems without building
    /// <summary>
    /// The click OK.
    /// </summary>
    public event VoidT<object> ClickOK;
    /// <summary>
    /// The title.
    /// </summary>
    public string Title
    {
        set
        {
            tbTitle.Text = value;
        }
    }
    /// <summary>
    /// The max content size.
    /// </summary>
    public Size MaxContentSize
    {
        get
        {
            //return maxContentSize;
            return FrameworkElementHelper.GetMaxContentSize(this);
        }
        set
        {
            //maxContentSize = value;
            FrameworkElementHelper.SetMaxContentSize(this, value);
        }
    }
    /// <summary>
    /// Musíš nastavit i Visible
    /// </summary>
    public string Collapse
    {
        set
        {
            ttCollapse.Content = value;
            if (!string.IsNullOrWhiteSpace(value))
            {
                tbCollapse.Visibility = Visibility.Visible;
            }
            else
            {
                tbCollapse.Visibility = Visibility.Collapsed;
            }
        }
    }
    /// <summary>
    /// Musíš nastavit i Collapsee
    /// </summary>
    public string Visible
    {
        set
        {
            tbChybovaZprava.Text = value;
        }
    }
    /// <summary>
    /// Initializes a new instance of the error listing class.
    /// </summary>
    public ErrorListing()
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
    private void OnClickOK(object sender, RoutedEventArgs eventArgs)
    {
        ClickOK(null);
    }
    /// <summary>
    /// The popup border brush.
    /// </summary>
    public Brush PopupBorderBrush
    {
        set { border.BorderBrush = value; }
    }
    /// <summary>
    /// The click cancel.
    /// </summary>
    public event VoidT<object> ClickCancel;

    #endregion
}
