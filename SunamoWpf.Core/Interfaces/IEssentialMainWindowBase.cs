namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i essential main window base type.
/// </summary>
public interface IEssentialMainWindowBase
{
    /// <summary>
    /// Set mode.
    /// </summary>
    /// <param name="mode">The mode.</param>
    void SetMode(object mode);
    /// <summary>
    /// Gets the mode string.
    /// </summary>
    string ModeString { get; }
}
