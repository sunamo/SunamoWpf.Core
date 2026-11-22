#define ASYNC
namespace SunamoWpf.Interfaces;

/// <summary>
/// IEssentialMainPage is in apps
/// Must be derived from IWindowOpener - without implement in MainWindow cant be shown exceptions window
/// </summary>
public interface IEssentialMainWindow : IEssentialMainWindowBase, IWindowOpener
{
    /// <summary>
    /// Gets or sets the actual.
    /// </summary>
    Control actual { get; set; }
}

/// <summary>
/// Represents the i essential main window selling type.
/// </summary>
public interface IEssentialMainWindowSelling : IEssentialMainWindowBase, IWindowOpener
{
    /// <summary>
    /// Gets or sets the actual r.
    /// </summary>
    FrameworkElement actualR { get; set; }
}
