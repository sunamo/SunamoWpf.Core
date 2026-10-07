#define ASYNC
namespace SunamoWpf.Helpers.ContainerControls;

public partial class WindowHelper
{
    public static void SizeOfWindowToTitle(Window window, RowDefinition growingRow, FrameworkElement content)
    {
        SizeOfWindowToTitle(window, growingRow.ActualHeight, content);
    }
    public static void SizeOfWindowToTitle(Window window, double growingRow, FrameworkElement content)
    {
        window.Title = $"Window: {window.ActualWidth}x{window.ActualHeight} growingRow: {growingRow} Content: {content.ActualWidth}x{content.ActualHeight}";
    }
    static IWindowOpener windowOpener = null;
    public static void ShowExceptionWindow2(object exception)
    {
        ShowExceptionWindow(exception, Environment.NewLine);
    }
    private static void Result_ChangeDialogResult(bool? result)
    {
        windowOpener.windowWithUserControl.Close();
    }
#if MB
    static void ShowMb(string s)
    {
        WpfApp.ShowMb(s);
    }
#endif
    static string lastError = null;
    static Action<string> sl => PD.WriteToStartupLogRelease;
    /// <summary>
    /// Return dump A1
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="methodName"></param>
    /// <returns></returns>
    public static string ShowExceptionWindow(object exception, string methodName = "", bool isTerminanting = false)
    {
        if (methodName != string.Empty)
        {
            methodName += " ";
        }
        string dump = null;
        //dump = YamlHelper.DumpAsYaml(e);
        //dump = SunamoJsonHelper.SerializeObject(e, true);
        //dump = JsonParser.Serialize<>
        dump = RH.DumpAsString(new DumpAsStringArgs { o = exception, d = DumpProvider.Reflection });
        if (dump == lastError)
        {
            return dump;
        }
        lastError = dump;
        StringBuilder stringBuilder = new StringBuilder();
        if (isTerminanting)
        {
            stringBuilder.AppendLine("Is terminating: YES");
            stringBuilder.AppendLine();
        }
        stringBuilder.AppendLine(methodName);
        stringBuilder.Append(dump);
        var result = new ShowTextResult(stringBuilder.ToString());
        result.ChangeDialogResult += Result_ChangeDialogResult;
        if (isTerminanting)
        {
            //result.txtResult.Background = Brushes.OrangeRed;
        }
        var mainWindow = Application.Current.MainWindow;
        windowOpener = mainWindow as IWindowOpener;
        if (windowOpener == null)
        {
            string windowOpenerIsNull = "windowOpener == null";
#if MB
            ShowMb(windowOpenerIsNull);
#endif
            sl(windowOpenerIsNull);
            var message = Translate.FromKey(XlfKeys.MainWindowMustBeIWindowOpenerDueToShowExceptions) + $"Is Application.Current.MainWindow null: {mainWindow == null}";
            if (mainWindow != null)
            {
                message += $"Type: {mainWindow.GetType()}";
            }
            MessageBox.Show(message);
        }
        else
        {
            var _a = "windowOpener.windowWithUserControl.ShowDialog";
#if MB
            ShowMb(_a);
#endif
            sl(_a);
            windowOpener.windowWithUserControl = new WindowWithUserControl(result, ResizeMode.CanResizeWithGrip, false);
            windowOpener.windowWithUserControl.ShowDialog();
        }
        return dump;
    }
    public static void Close(Window window)
    {
        try
        {
            window.Close();
        }
        catch (Exception)
        {
        }
    }
}
