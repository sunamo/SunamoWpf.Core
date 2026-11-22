#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class UIElementHelper
{
    /// <summary>
    /// Set visibility.
    /// </summary>
    /// <param name="isVisible">The is visible.</param>
    /// <param name="elements">The elements.</param>
    public static void SetVisibility(bool isVisible, params UIElement[] elements)
    {
        foreach (var item in elements)
        {
            item.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
