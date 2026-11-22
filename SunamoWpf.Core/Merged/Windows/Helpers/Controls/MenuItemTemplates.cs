#define ASYNC
namespace SunamoWpf.Helpers.Controls;

/// <summary>
/// Represents the su menu item templates type.
/// </summary>
public class SuMenuItemTemplates
{
    /// <summary>
    /// Available shortcut.
    /// </summary>
    /// <param name="dictionary2">The dictionary 2.</param>
    /// <returns>The available shortcut result.</returns>
    public static SuMenuItem AvailableShortcut(Dictionary<string, string> dictionary2)
    {
        SuMenuItem miShowControls = new SuMenuItem();
        miShowControls.Click += delegate
        {
            WindowWithUserControl.AvailableShortcut(dictionary2);
        };
        miShowControls.Header = "AvailableShortcuts" + "...";
        return miShowControls;
    }
}