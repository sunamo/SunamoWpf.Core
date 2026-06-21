namespace SunamoWpf;

public static partial class WriterEventLog
{
    static EventLog mainEventLogOfApplication = null;
    public const string ApplicationLogName = XlfKeys.Application;
    static EventLog eventLogWindowsApplication = null;
    static string scz = "sunamo.cz";

    public static void WriteException(string stacktrace, string exception)
    {
        if (!IsAdmin())
        {
            return;
        }
        WriterEventLog.WriteToMainAppLog(exception + Environment.NewLine + stacktrace, EventLogEntryType.Error);
    }

    #region In scz never call CreateMainAppLogScz, so commented it
    //public static void WriteToMainAppLogScz(string text, EventLogEntryType type)
    //{
    //    if (!IsAdmin())
    //    {
    //        return;
    //    }
    //    WriteToWindowsLogs(scz, text, type);
    //}

    //public static bool CreateMainAppLogScz()
    //{
    //    if (!IsAdmin())
    //    {
    //        return false;
    //    }
    //    bool b = CreateMainAppLog(scz);
    //    WriteToMainAppLogScz(sess.i18n(XlfKeys.Template), EventLogEntryType.Information);
    //    return b;
    //} 
    #endregion

    /// <summary>
    /// Zda to funguje nevím, já už jsem v aplikaci zapisoval metodou WriteToMainAppLog a žádná aplikace nemůže zapisovat do více logů
    /// </summary>
    /// <param name = "text"></param>
    /// <param name = "type"></param>
    public static void WriteToWindowsLogs(string appName, string text, EventLogEntryType type)
    {
        if (!IsAdmin())
        {
            return;
        }

        // Exists every time. Cant iterate - SecurityException will be happen in asp.net app
        if (!EventLog.SourceExists(appName))
        {
            EventLog.CreateEventSource(new EventSourceCreationData(appName, ApplicationLogName));
        }

        if (eventLogWindowsApplication == null)
        {
            eventLogWindowsApplication = new EventLog();
            eventLogWindowsApplication.Source = appName;
        }

        eventLogWindowsApplication.WriteEntry(text, type);
    }

    private static string _eventLogName = null;

    /// <summary>
    /// EN: Set event log name for logging. Must be called before using WriteToMainAppLog.
    /// CZ: Nastaví název event logu pro logování. Musí být zavoláno před použitím WriteToMainAppLog.
    /// </summary>
    public static void SetEventLogName(string eventLogName)
    {
        _eventLogName = eventLogName;
    }

    /// <summary>
    /// EN: Requires admin rights. Use WriteToWindowsLogsApplication() in web apps.
    /// CZ: Vyžaduje admin práva. Ve webových aplikacích použij WriteToWindowsLogsApplication().
    /// </summary>
    public static void WriteToMainAppLog(string text, EventLogEntryType type, string methodName = null, string eventLogName = null)
    {
        string name = eventLogName ?? _eventLogName;

        if (string.IsNullOrWhiteSpace(name))
        {
            // CZ: Pokud není nastaven event log name, nemůžeme logovat
            // EN: If event log name is not set, we cannot log
            return;
        }

        if (!IsAdmin())
        {
            return;
        }

        if (methodName != null)
        {
            text = methodName + ": " + text;
        }

        CreateMainAppLog(name);
        if (mainEventLogOfApplication == null)
        {
            mainEventLogOfApplication = new EventLog(name);
            mainEventLogOfApplication.Source = name;
        }

        mainEventLogOfApplication.WriteEntry(text, type);
    }

    public static bool IsAdmin()
    {
        return false;
        //return WindowsSecurityHelper.IsUserAdministrator();
    }

    public static bool CreateMainAppLog(string notThisAppNameJustEventLogNames)
    {
        if (!IsAdmin())
        {
            return false;
        }
        //if (EventLog.SourceExists(name))
        //{
        //    // Excetpion: The event log source 'sunamo.cz' cannot be deleted, because it's equal to the log name.
        //    System.Diagnostics.EventLog.DeleteEventSource("sunamo.cz");
        //}

        bool existsSource = false;
        try
        {
            /*SourceExists
Tohle je divné že stačí odebrat .Wpf a už mi to jednak nenajde přes SourceExists
zároveŇ CreateEventSource mi hlásí pře existuje
Only the first eight characters of a custom log name are significant, and there is already another log on the system using the first eight characters of the name given. Name given: 'AllProjectsSearch', name of existing log: 'AllProjectsSearch.Wpf'.'

            Nicméně to dává smysl, existuje log .Wpf, proto už nemůžu vytvořit bez .wpf
            proto musím mít speciální třídu jen pro názvy v eventlogu
             */

            existsSource = EventLog.SourceExists(notThisAppNameJustEventLogNames);
        }
        catch (Exception ex)
        {
        }

        if (!existsSource)
        {
            //EventLog.Delete("SunamoAdmin");
            // Zkoušel jsme zadávat do metody CreateEventSource argumenty source, logName s hodnotami name, logName ale s těmi to taky nefungovalo
            EventLog.CreateEventSource(new EventSourceCreationData(notThisAppNameJustEventLogNames, notThisAppNameJustEventLogNames));
        }

        return existsSource;
    }


}