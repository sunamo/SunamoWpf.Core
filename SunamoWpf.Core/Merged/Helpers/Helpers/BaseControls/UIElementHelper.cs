#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

/// <summary>
/// Represents the UI element helper type.
/// </summary>
public partial class UIElementHelper
{
    /// <summary>
    /// Set is enabled.
    /// </summary>
    /// <param name="isEnabled">The is enabled.</param>
    /// <param name="elements">The elements.</param>
    public static void SetIsEnabled(bool isEnabled, params UIElement[] elements)
    {
        foreach (var item in elements)
        {
            item.IsEnabled = isEnabled;
        }
    }

}