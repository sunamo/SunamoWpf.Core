#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class UIElementHelper
{
    public static void SetIsEnabled(bool isEnabled, params UIElement[] elements)
    {
        foreach (var item in elements)
        {
            item.IsEnabled = isEnabled;
        }
    }

}