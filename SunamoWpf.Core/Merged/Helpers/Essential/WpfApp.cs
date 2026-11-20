#define ASYNC
namespace SunamoWpf.Essential;



/// <summary>
/// Represents the wpf app type.
/// </summary>
public partial class WpfApp
{
    static WpfApp()
    {
        EnableDesktopLogging(true);
    }
    /// <summary>
    /// The write to startup log release.
    /// </summary>
    public static Action<string> WriteToStartupLogRelease;
    /// <summary>
    /// Delegate set by Windows layer to show exception window. Avoids circular dependency.
    /// </summary>
    public static Action<object> ShowExceptionWindow2Delegate;
    /// <summary>
    /// Delegate set by Windows layer to show exception window with args. Returns dump string.
    /// </summary>
    public static Func<object, string, bool, string> ShowExceptionWindowDelegate;
    /// <summary>
    /// Show mb.
    /// </summary>
    /// <param name="text">The text.</param>
    public static void ShowMb(string text)
    {
        reallyThrow = ThrowEx.reallyThrow2;
        ThrowEx.reallyThrow2 = false;
        if (WriteToStartupLogRelease != null)
        {
            WriteToStartupLogRelease(text);
        }
        ThrowEx.reallyThrow2 = reallyThrow;
    }
    /// <summary>
    /// Shutdown.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="eventArgs">The event args.</param>
    public static void Shutdown(object sender, EventArgs eventArgs)
    {
        WpfApp.htt.SetCancelClosing(false);
        WpfApp.window.Close();
    }
    /// <summary>
    /// Restart.
    /// </summary>
    public static void Restart()
    {
        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        Application.Current.Shutdown();
    }
    // Is not available in SunamoWpf.web
    //public static void Restart2()
    //{
    //    System.Windows.Forms.Application.Restart();
    //    System.Windows.Application.Current.Shutdown();
    //}
    static DependencyProperty[] props = new DependencyProperty[] { TextBlock.ForegroundProperty, TextBlock.TextProperty };
    /// <summary>
    /// SQL express instance name.
    /// </summary>
    /// <returns>The SQL express instance name result.</returns>
    public static string SQLExpressInstanceName()
    {
        return Environment.MachineName;
    }
#if DEBUG
    /// <summary>
    /// Write debug.
    /// </summary>
    /// <param name="v">The v.</param>
    public static void WriteDebug(string v)
    {
        Debug.WriteLine(v);
    }
#endif
    /// <summary>
    /// Alternatives are:
    /// //InitApp.SetDebugLogger
    /// CmdApp.SetLogger
    /// WpfApp.SetLogger
    /// </summary>
    public static void SetLogger()
    {
        ////InitApp.Logger = SunamoLogger.Logger.LoggerBaseNS.SunamoLogger.Instance;
        ////InitApp.TemplateLogger = //SunamoTemplateLogger.Instance;
        ////InitApp.TypedLogger = TypedSunamoLogger.Instance;
    }
    /// <summary>
    /// Save reference to text block status.
    /// </summary>
    /// <param name="restore">The restore.</param>
    /// <param name="tbTemporaryLastErrorOrWarning">The tb temporary last error or warning.</param>
    /// <param name="tbTemporaryLastOtherMessage">The tb temporary last other message.</param>
    public static void SaveReferenceToTextBlockStatus(bool restore, TextBlock tbTemporaryLastErrorOrWarning, TextBlock tbTemporaryLastOtherMessage)
    {
        if (restore)
        {
            tbLastErrorOrWarning = tbLastErrorOrWarningSaved;
            tbLastOtherMessage = tbLastOtherMessageSaved;
        }
        else
        {
            tbLastErrorOrWarningSaved = tbLastErrorOrWarning;
            tbLastOtherMessageSaved = tbLastOtherMessage;
        }
        if (!restore)
        {
            tbLastErrorOrWarning = tbTemporaryLastErrorOrWarning;
            tbLastOtherMessage = tbTemporaryLastOtherMessage;
        }
    }
    private static void SetForeground(TextBlock tbLastOtherMessage, Color color)
    {
        if (tbLastOtherMessage != null)
        {
            WpfApp.cd.Invoke(() =>
            {
                tbLastOtherMessage.Foreground = new SolidColorBrush(color);
            }
            );
        }
    }
    //static List<string> otherStatuses = new List<string>();
    //static List<string> errorStatuses = new List<string>();
    //public static void ClearRemembered()
    //{
    //    otherStatuses.Clear();
    //    errorStatuses.Clear();
    //}
    private static void SetStatus(TypeOfMessageWpf typeOfMessage, string status)
    {
        status = DateTime.Now.ToShortTimeString() + " " + status;
        Color foreground = StatusHelper.GetForegroundBrushOfTypeOfMessage(typeOfMessage);
        if (typeOfMessage == TypeOfMessageWpf.Error || typeOfMessage == TypeOfMessageWpf.Warning)
        {
            // tbLastErrorOrWarning must be defined otherwise wont be adding to lbLogsErrors also
            //if (tbLastErrorOrWarning != null)
            //{
            SetForeground(tbLastErrorOrWarning, foreground);
            TextBlockHelper.SetText(tbLastErrorOrWarning, status);
            if (lbLogsErrors != null)
            {
                TextBlock txt = DependencyObjectHelper.CreatedWithCopiedValues<TextBlock>(tbLastErrorOrWarning, props);
                cd.Invoke(() =>
                {
                    txt.ToolTip = tbLastErrorOrWarning.Text;
                    lbLogsErrors.Children.Insert(0, txt);
                });
            }
            //}
        }
        else
        {
            // tbLastOtherMessage must be defined otherwise wont be adding to lbLogsErrors also
            //if (tbLastOtherMessage != null)
            //{
            SetForeground(tbLastOtherMessage, foreground);
            TextBlockHelper.SetText(tbLastOtherMessage, status);
            if (lbLogsOthers != null)
            {
                TextBlock txt = DependencyObjectHelper.CreatedWithCopiedValues<TextBlock>(tbLastOtherMessage, props);
                cd.Invoke(() =>
                {
                    txt.ToolTip = tbLastOtherMessage.Text;
                    lbLogsOthers.Children.Insert(0, txt);
                    //lbLogsOthers.InvalidateVisual();
                    //lbLogsOthers.UpdateLayout();
                    //lbLogsOthers.Children.Insert(0, new TextBlock());
                    //lbLogsOthers.Children.RemoveAt(0);
                    //lbLogsOthers.InvalidateArrange();
                    //lbLogsOthers.UpdateLayout();
                    //lbLogsOthers.
                }
                , DispatcherPriority.Render);
            }
            //}
        }
    }
    /// <summary>
    /// EN: Event triggered when status message is set
    /// CZ: Event vyvolaný když je nastavena status zpráva
    /// </summary>
    public static event Action<TypeOfMessageWpf, string> StatusSetted;

    /// <summary>
    /// Enable desktop logging.
    /// </summary>
    /// <param name="value">The value.</param>
    public static void EnableDesktopLogging(bool value)
    {
        if (value)
        {
            // CZ: Povolit desktop logování - nyní se používá StatusSetted event
            // EN: Enable desktop logging - now uses StatusSetted event
            StatusSetted -= ThisApp_StatusSetted;
            StatusSetted += ThisApp_StatusSetted;
        }
        else
        {
            StatusSetted -= ThisApp_StatusSetted;
        }
    }

    private static void ThisApp_StatusSetted(TypeOfMessageWpf typeOfMessage, string message)
    {
        SetStatus(typeOfMessage, message);
    }
    // TODO: Rename to SetStatusAsync and merge with commented method SetStatus here
    /// <summary>
    /// Set status to text block.
    /// </summary>
    /// <param name="typeOfMessage">The type of message.</param>
    /// <param name="status">The status.</param>
    public async static Task SetStatusToTextBlock(TypeOfMessageWpf typeOfMessage, string status)
    {
        Color foreground = Colors.Black;
        if (typeOfMessage == TypeOfMessageWpf.Error || typeOfMessage == TypeOfMessageWpf.Warning)
        {
            await SetForegroundAsync(tbLastErrorOrWarning, foreground);
            await SetTextAsync(tbLastErrorOrWarning, status);
        }
        else
        {
            await SetForegroundAsync(tbLastOtherMessage, foreground);
            await SetTextAsync(tbLastOtherMessage, status);
        }
    }
    /// <summary>
    /// Set foreground async.
    /// </summary>
    /// <param name="tbLastOtherMessage">The tb last other message.</param>
    /// <param name="color">The color.</param>
    public async static Task SetForegroundAsync(TextBlock tbLastOtherMessage, Color color)
    {
        await cd.InvokeAsync(() =>
        {
            tbLastOtherMessage.Foreground = new SolidColorBrush(color);
        }
        , cdp);
    }
    /// <summary>
    /// Set text async.
    /// </summary>
    /// <param name="lblStatusDownload">The lbl status download.</param>
    /// <param name="status">The status.</param>
    public async static Task SetTextAsync(TextBlock lblStatusDownload, string status)
    {
        await cd.InvokeAsync(() =>
        {
            lblStatusDownload.Text = status;
        }
        , cdp);
    }
    static IEssentialMainWindowBase _mp = null;
    /// <summary>
    /// The window.
    /// </summary>
    public static Window window = null;
    /// <summary>
    /// The htt.
    /// </summary>
    public static IHideToTray htt = null;
    /// <summary>
    /// The mp.
    /// </summary>
    public static IEssentialMainWindowBase mp
    {
        get
        {
            return _mp;
        }
        set
        {
            _mp = value;
            window = (Window)value;
            // Without it, app would be still running after close
            window.Closed += (sender, eventArgs) => window.Dispatcher.InvokeShutdown();
        }
    }
    /// <summary>
    /// The tb last error or warning.
    /// </summary>
    public static TextBlock tbLastErrorOrWarning = null;
    /// <summary>
    /// The tb last other message.
    /// </summary>
    public static TextBlock tbLastOtherMessage = null;
    static TextBlock tbLastErrorOrWarningSaved = null;
    static TextBlock tbLastOtherMessageSaved = null;
    static StackPanel lbLogsOthers = null;
    static StackPanel lbLogsErrors = null;
    /// <summary>
    /// The cd.
    /// </summary>
    public static Dispatcher cd = null;
    /// <summary>
    /// The cdp.
    /// </summary>
    public static DispatcherPriority cdp = DispatcherPriority.Normal;
    /// <summary>
    /// The remember statuses.
    /// </summary>
    public static bool rememberStatuses;
    /// <summary>
    /// Save reference to logs stack panel.
    /// </summary>
    /// <param name="_lbLogsOthers">The lb logs others.</param>
    /// <param name="_lbLogsErrors">The lb logs errors.</param>
    public static void SaveReferenceToLogsStackPanel(StackPanel _lbLogsOthers, StackPanel _lbLogsErrors)
    {
        lbLogsErrors = _lbLogsErrors;
        lbLogsOthers = _lbLogsOthers;
    }
}
