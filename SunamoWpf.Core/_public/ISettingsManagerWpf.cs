namespace SunamoWpf._public;

/// <summary>
/// Represents the i settings manager wpf framework element dependency property type.
/// </summary>
public interface ISettingsManagerWpf<FrameworkElement, DependencyProperty>
{
    /// <summary>
    /// Add from saved elements.
    /// </summary>
    /// <param name="list">The list.</param>
    void AddFromSavedElements(TUListWpf<FrameworkElement, DependencyProperty> list);
    /// <summary>
    /// Load settings.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="savedElements">The saved elements.</param>
    void LoadSettings(FrameworkElement sender, TUListWpf<FrameworkElement, DependencyProperty> savedElements);
    /// <summary>
    /// Save settings.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="savedElements">The saved elements.</param>
    void SaveSettings(FrameworkElement sender, TUListWpf<FrameworkElement, DependencyProperty> savedElements);
}