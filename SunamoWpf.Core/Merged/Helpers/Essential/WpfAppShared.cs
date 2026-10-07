#define ASYNC
namespace SunamoWpf.Essential;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public partial class WpfApp
{
    /// <summary>
    ///  for this + registers handlers in App attention, on whole yesterday and partially today I spend many time where is erros because Exceptions windows is disabled
    /// </summary>
    static bool breakAt = true;
    static bool handled = true;
    static bool initialized = false;
    static bool attached = false;

    public static Type type = typeof(WpfApp);

    /// <summary>
    /// sl = startup log
    /// </summary>
    public static Action<string> sl
    {
        get
        {
            var logAction = PD.WriteToStartupLogRelease;
            return logAction != null ? logAction : (string message) => { };
        }
    }


    public static void Init(Dispatcher dispatcher)
    {
        string initWpfApp = "Init WpfApp";

        WpfApp.cd = dispatcher;
#if MB
        ShowMb(initWpfApp);
#endif

        sl(initWpfApp);


        if (!initialized)
        {
            //CA.dCountSunExc = new Func<IList, int>(r => WpfApp.DispatcherAction<IList, int>(dCount, r));
            //CA.dFirstOrNull = new Func<IList, object>(r => WpfApp.DispatcherAction<IList, object>(dFirstOrNull, r));

            string insideIf = "inside if";
#if MB
            ShowMb(insideIf);
#endif
            sl(insideIf);

            initialized = true;

            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;

            string attachIsReleased = "attach in release";
#if MB
            ShowMb(attachIsReleased);
            AttachHandlers();
#endif
            sl(attachIsReleased);


            // change ! by needs
            if (!Debugger.IsAttached)
            {
                string debuggerWasntAttached = "Debugger wasnt attached";
#if MB
                ShowMb(debuggerWasntAttached);
#endif
                sl(debuggerWasntAttached);
                AttachHandlers();


            }
            else
            {
                string debuggerWasAttached = "Debugger was attached, no exceptions handlers is attached";
#if MB
                ShowMb(debuggerWasAttached);
#endif
                sl(debuggerWasAttached);
            }


        }
    }

    #region MyRegion
    private static int dCount(IList arg)
    {
        int index = 0;
        foreach (var item in arg)
        {
            index++;
        }

        return index;
    }

    //private static object dFirstOrNull(IList arg)
    //{
    //    int i = 0;
    //    foreach (var item in arg)
    //    {
    //        return item;
    //    }

    //    return null;
    //}

    private static T2 DispatcherAction<T1, T2>(Func<T1, T2> count, T1 argument)
    {
        T2 result = WpfApp.cd.Invoke(() => count(argument));
        return result;
    }
    #endregion


    /// <summary>
    ///
    /// Nevím proč v hodně apps jsem odchytával jen CurrentDomain_UnhandledException, zda to stačilo nebo proč
    /// </summary>
    private static void AttachHandlers()
    {
        if (!attached)
        {
            string notAttached = "!attached";
#if MB
            ShowMb(notAttached);
#endif
            sl(notAttached);

            attached = true;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            // Is handled also in Current_DispatcherUnhandledException , then will be opened two windows
            // have IsHandled
            WpfApp.cd.UnhandledException += Current_DispatcherUnhandledException;
            // have IsHandled
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            // Has SetObserved
            //     Marks the System.Threading.Tasks.UnobservedTaskExceptionEventArgs.Exception as
            //     "observed," thus preventing it from triggering exception escalation policy which,
            //     by default, terminates the process.
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            string notAttachedFinished = "!attached finished";
#if MB
            ShowMb(notAttachedFinished);
#endif
            sl(notAttachedFinished);
        }
        else
        {
            string attached = "attached !!!";
#if MB
            ShowMb(attached);
#endif
            sl(attached);
        }
    }

    static void DebuggerIsAttached()
    {
        string debuggerIsAttached = "DebuggerIsAttached";
        //ShowMb(debuggerIsAttached);
        //Debugger.Break();
        sl(debuggerIsAttached);
    }

    private static bool IsSomethingNull(string handler)
    {
        string isSomethingNull = "IsSomethingNull " + handler;
#if MB
        // Here must be ShowMb, not TranslateDictionary.ShowMb, which could not be attached here!
        ShowMb(isSomethingNull);
#endif
        sl(isSomethingNull);

        WpfApp.cd = Application.Current.Dispatcher;
        if (WpfApp.ShowExceptionWindow2Delegate != null)
        {
            ThrowEx.showExceptionWindow = WpfApp.ShowExceptionWindow2Delegate;
        }
        WpfApp.cdp = System.Windows.Threading.DispatcherPriority.Normal;

        string _a = DesktopNotTranslateAble.EnteringIsSomethingNull;
#if MB
        ShowMb(_a);
#endif
        sl(_a);

        bool result = false;
        bool vr2 = false;

        if (WpfApp.cd == null)
        {
            result = true;
        }

        if (PD.delShowMb == null)
        {
            vr2 = true;
        }

        if (result || vr2)
        {
            bool run = false;
            if (result)
            {
                string _b = DesktopNotTranslateAble.WpfAppCdWasNull;
#if MB
                ShowMb(_b);
#endif
                sl(_b);
                run = true;
            }
            if (vr2)
            {
                string _c = DesktopNotTranslateAble.PDDelShowMbWasNull;
#if MB
                ShowMb(_c);
#endif
                sl(_c);
                run = true;
            }

            Exception exception = new Exception();

            try
            {
                string _d = DesktopNotTranslateAble.EmptyTryBlock;
#if MB
                ShowMb(_d);
#endif
                sl(_d);
            }
            catch (Exception ex2)
            {
                exception = ex2;

                string _e = DesktopNotTranslateAble.CatchBlockFromEmptyTryBlock;
#if MB
                ShowMb(_e);
#endif
                sl(_e);
            }

            //sb.AppendLine("Is my computer");
            //run = WindowsSecurityHelper.IsMyComputer();

            if (run)
            {
                string newLine = Environment.NewLine;
                var err = handler + newLine +Exceptions.TextOfExceptions(exception);
                Debug.WriteLine(err);

                string _f = handler + " " + DesktopNotTranslateAble.SomethingIsNullProbablyWpfAppCdIntoClipboardAndDebugWasCopiedStacktrace + ".";
#if MB
                ShowMb(_f);
#endif
                sl(_f);

                ClipboardService.SetText(err);
            }
            return true;
        }
        else
        {
            string _g = handler + " Everything is ok";
#if MB
            ShowMb(_g);
#endif
            sl(_g);

            return false;
        }
    }

    /// <summary>
    /// A2 = name of calling method (like Current_DispatcherUnhandledException)
    /// </summary>
    /// <param name="eventArgs"></param>
    /// <param name="name"></param>
    public static void ShowExceptionWindow(EventArgs eventArgs, string name, bool isTerminanting = false)
    {
        string showExceptionWindow = "ShowExceptionWindow";
#if MB
        ShowMb(showExceptionWindow);
#endif
        sl(showExceptionWindow);

        var dump = WpfApp.ShowExceptionWindowDelegate != null
            ? WpfApp.ShowExceptionWindowDelegate(eventArgs, name, isTerminanting)
            : null;

        WriterEventLog.WriteToMainAppLog(name + Environment.NewLine + dump, System.Diagnostics.EventLogEntryType.Error, Exceptions.CallingMethod());
    }

    static Type typeSEH = typeof(System.Runtime.InteropServices.SEHException);

    private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs eventArgs)
    {
        reallyThrow = ThrowEx.reallyThrow2;
        ThrowEx.reallyThrow2 = false;

        if (IsSomethingNull("TaskScheduler_UnobservedTaskException"))
        {
            return;
        }

        var typeExc = eventArgs.Exception.GetType();
        if (typeExc == typeSEH)
        {

        }
        var typeName = typeExc.Name;

        //https://stackoverflow.com/a/7883087/9327173
        eventArgs.SetObserved();

        WpfApp.cd.Invoke(() =>
        {
            if (!Debugger.IsAttached)
            {
                ShowExceptionWindow(eventArgs, "TaskScheduler_UnobservedTaskException");
            }
            else { if (breakAt) { DebuggerIsAttached(); } }
        }
        );
        ThrowEx.reallyThrow2 = reallyThrow;
    }

    static bool reallyThrow = false;

    /// <summary>
    /// 3
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    private static void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs eventArgs)
    {
        reallyThrow = ThrowEx.reallyThrow2;
        ThrowEx.reallyThrow2 = false;
        #region MyRegion
        // https://stackoverflow.com/a/13523188
        var comException = eventArgs.Exception as System.Runtime.InteropServices.COMException;

        if (comException != null && comException.ErrorCode == -2147221040)
            eventArgs.Handled = true;

        var typeExc = eventArgs.Exception.GetType();
        if (typeExc == typeSEH)
        {

        }
        #endregion

        // cd je null
        if (IsSomethingNull("Current_DispatcherUnhandledException"))
        {
            return;
        }

        eventArgs.Handled = handled;
        WpfApp.cd.Invoke(() =>
        {
            if (!Debugger.IsAttached)
            {
                eventArgs.Handled = true;
                ShowExceptionWindow(eventArgs, "Current_DispatcherUnhandledException");
            }
            else { if (breakAt) { DebuggerIsAttached(); } }

        }
        );
        ThrowEx.reallyThrow2 = reallyThrow;
    }

    /// <summary>
    /// 2
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs eventArgs)
    {
        reallyThrow = ThrowEx.reallyThrow2;
        ThrowEx.reallyThrow2 = false;

        if (IsSomethingNull("CurrentDomain_UnhandledException"))
        {
            return;
        }


        var typeExc = eventArgs.ExceptionObject.GetType();
        if (typeExc == typeSEH)
        {

        }

        WpfApp.cd.Invoke(() =>
        {
            if (!Debugger.IsAttached)
            {
                ShowExceptionWindow(eventArgs, "CurrentDomain_UnhandledException", eventArgs.IsTerminating);
            }
            else { if (breakAt) { DebuggerIsAttached(); } }
        }
        );
        ThrowEx.reallyThrow2 = reallyThrow;
    }
}