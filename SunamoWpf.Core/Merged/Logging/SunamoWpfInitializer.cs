namespace SunamoWpf;

/// <summary>
/// EN: Public API for initializing SunamoWpf library
/// CZ: Veřejné API pro inicializaci SunamoWpf knihovny
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public static class SunamoWpfInitializer
{
    /// <summary>
    /// EN: Initialize SunamoWpf with application name. MUST be called before using any SunamoWpf features.
    /// CZ: Inicializuje SunamoWpf s názvem aplikace. MUSÍ být zavoláno před použitím jakýchkoliv SunamoWpf funkcí.
    /// </summary>
    /// <param name="applicationName">EN: Name of the entry assembly (e.g., "SunamoAdmin.Wpf") / CZ: Název entry assembly (např. "SunamoAdmin.Wpf")</param>
    /// <param name="eventLogName">EN: Optional event log name / CZ: Volitelný název event logu</param>
    public static void Initialize(string applicationName, string eventLogName = null)
    {
        if (string.IsNullOrWhiteSpace(applicationName))
        {
            throw new ArgumentException("Application name cannot be null or empty", nameof(applicationName));
        }

        // CZ: Inicializujeme jednotlivé komponenty SunamoWpf s názvem aplikace
        // EN: Initialize individual SunamoWpf components with application name
        _shared.Helpers.Resources.EmbeddedResourcesHShared.Initialize(applicationName);
        _sunamo.RA.Initialize(applicationName);

        if (!string.IsNullOrWhiteSpace(eventLogName))
        {
            WriterEventLog.SetEventLogName(eventLogName);
        }
    }

    /// <summary>
    /// EN: Set logging callbacks for WpfLogger. Optional - if not set, logging will be silent.
    /// CZ: Nastaví logging callbacky pro WpfLogger. Volitelné - pokud není nastaveno, logování bude tiché.
    /// </summary>
    public static void SetLoggingCallbacks(
        Action<string> info = null,
        Action<string> error = null,
        Action<string> warning = null,
        Action<string> success = null,
        Action<string> appeal = null)
    {
        if (info != null) WpfLogger.Info = info;
        if (error != null) WpfLogger.Error = error;
        if (warning != null) WpfLogger.Warning = warning;
        if (success != null) WpfLogger.Success = success;
        if (appeal != null) WpfLogger.Appeal = appeal;
    }
}
