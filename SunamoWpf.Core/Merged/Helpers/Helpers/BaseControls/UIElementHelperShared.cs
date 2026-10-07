#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class UIElementHelper
{
    public static void SetVisibility(bool isVisible, params UIElement[] elements)
    {
        foreach (var item in elements)
        {
            item.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
