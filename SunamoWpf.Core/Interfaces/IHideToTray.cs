namespace SunamoWpf.Interfaces;

/// <summary>
/// Represents the i hide to tray type.
/// </summary>
public interface IHideToTray
{
    // cant be Title as in UC, because Window has own Property
    /// <summary>
    /// Gets or sets the cancel closing.
    /// </summary>
    bool CancelClosing { get; set; }

    /// <summary>
    /// Get cancel closing.
    /// </summary>
    /// <returns>The get cancel closing result.</returns>
    bool GetCancelClosing();
    /// <summary>
    /// Set cancel closing.
    /// </summary>
    /// <param name="cancelClosing">The cancel closing.</param>
    void SetCancelClosing(bool cancelClosing);
}