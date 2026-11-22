#define ASYNC
namespace SunamoWpf.UserControls;

public partial class EmptyUC : UserControl, IUserControl, IKeysHandler
{
    /// <summary>
    /// Initializes a new instance of the empty UC class.
    /// </summary>
    public EmptyUC()
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

        Loaded += uc_Loaded;
    }

    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => "Empty";

    /// <summary>
    /// The window with user control.
    /// </summary>
    public WindowWithUserControl windowWithUserControl
    {
        get =>
            ((IWindowOpener)Application.Current.MainWindow).windowWithUserControl;
        set =>
             ((IWindowOpener)Application.Current.MainWindow).windowWithUserControl = value;
    }

    /// <summary>
    /// Handle key.
    /// </summary>
    /// <param name="eventArgs">The event args.</param>
    /// <returns>The handle key result.</returns>
    public bool HandleKey(KeyEventArgs eventArgs)
    {
        return false;
    }

    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {

    }

    /// <summary>
    /// Uc loaded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
    {

    }
}
