#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

/// <summary>
/// Represents the button helper desktop 2 type.
/// </summary>
public class ButtonHelperDesktop2
{
    /// <summary>
    /// Perform click.
    /// </summary>
    /// <param name="someButton">The some button.</param>
    public static void PerformClick(ButtonBase someButton)
    {
        someButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
    }
}