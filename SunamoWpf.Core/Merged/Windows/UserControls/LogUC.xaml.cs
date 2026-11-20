#define ASYNC
namespace SunamoWpf.UserControls;

public partial class LogUC : UserControl, IUserControl, IWindowOpener, IUserControlShared, IKeysHandler, ISaveWithoutArgWpf, IUserControlClosing
{
    #region Rewrite to pure cs. With xaml is often problems without building
    /// <summary>
    /// Initializes a new instance of the log UC class.
    /// </summary>
    public LogUC()
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

        uc_Loaded(null, null);
    }

    /// <summary>
    /// Gets the title.
    /// </summary>
    public string Title => "Logs";
    bool initialized = false;
    /// <summary>
    /// Gets the window with user control.
    /// </summary>
    public WindowWithUserControl windowWithUserControl { get => windowOpenerMain.windowWithUserControl; set => windowOpenerMain.windowWithUserControl = value; }

    IKeysHandler keyHandlerMain = null;
    IEssentialMainWindow mainControl = null;
    IWindowOpener windowOpenerMain = null;

    /// <summary>
    /// The main control.
    /// </summary>
    public IEssentialMainWindow MainControl
    {
        get { return mainControl; }
        set
        {
            mainControl = value;

            if (value is IKeysHandler)
            {
                keyHandlerMain = (IKeysHandler)value;
            }
            if (value is IWindowOpener)
            {
                windowOpenerMain = (IWindowOpener)value;
            }
        }
    }

    /// <summary>
    /// Handle key.
    /// </summary>
    /// <param name="eventArgs">The event args.</param>
    /// <returns>The handle key result.</returns>
    public bool HandleKey(KeyEventArgs eventArgs)
    {
        if (keyHandlerMain != null)
        {
            if (keyHandlerMain.HandleKey(eventArgs))
            {
                //return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
        if (!initialized)
        {
            initialized = true;


        }
    }

    /// <summary>
    /// Uc loaded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public void uc_Loaded(object sender, RoutedEventArgs eventArgs)
    {
        WpfApp.sl("LogUC loaded");
    }

    /// <summary>
    /// Save.
    /// </summary>
    /// <param name="path">The path.</param>
    public void Save(string path)
    {
        lbLogsErrors.Save(path);
        lbLogsOthers.Save(path);
    }

    /// <summary>
    /// Open in code.
    /// </summary>
    /// <param name="PHWinCode">The PH win code.</param>
    public void OpenInCode(Action<string> PHWinCode)
    {
        PHWinCode(lbLogsErrors.fileToSave);
        PHWinCode(lbLogsOthers.fileToSave);

    }

    /// <summary>
    /// On closing.
    /// </summary>
    public void OnClosing()
    {

    }
    #endregion
}
