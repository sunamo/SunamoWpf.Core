#define ASYNC
namespace SunamoWpf.Controls.Controls;

public static partial class TwoStatesToggleButton{

    static Dictionary<ToggleButton, bool?> previousCheched = new Dictionary<ToggleButton, bool?>();
    /// <summary>
    /// Is checked.
    /// </summary>
    /// <param name="toggleButton">The toggle button.</param>
    /// <returns>The is checked result.</returns>
    public static bool IsChecked(ToggleButton toggleButton)
    {
        return previousCheched[toggleButton].Value;
    } 
}