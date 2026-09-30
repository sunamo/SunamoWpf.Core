namespace SunamoWpf.Logging;

/// <summary>
/// EN: Static logger for WPF applications. Configure callbacks before use.
/// CZ: Statický logger pro WPF aplikace. Nakonfigurujte callbacky před použitím.
/// </summary>
public static class WpfLogger
{
    /// <summary>
    /// EN: Callback for info messages
    /// CZ: Callback pro informační zprávy
    /// </summary>
    public static Action<string> Info { get; set; } = (msg) => { };

    /// <summary>
    /// EN: Callback for error messages
    /// CZ: Callback pro chybové zprávy
    /// </summary>
    public static Action<string> Error { get; set; } = (msg) => { };

    /// <summary>
    /// EN: Callback for warning messages
    /// CZ: Callback pro varovné zprávy
    /// </summary>
    public static Action<string> Warning { get; set; } = (msg) => { };

    /// <summary>
    /// EN: Callback for success messages
    /// CZ: Callback pro úspěšné zprávy
    /// </summary>
    public static Action<string> Success { get; set; } = (msg) => { };

    /// <summary>
    /// EN: Callback for appeal messages
    /// CZ: Callback pro výzvy
    /// </summary>
    public static Action<string> Appeal { get; set; } = (msg) => { };
}
