#define ASYNC
namespace SunamoWpf.ConfigurableWindow;

/// <summary>
/// ConfigurableWindowHelper - for use when Window is xaml
/// ConfigurableWindowInstance - for use when Window is only cs. Must be Instance because ConfigurableWindow is namespace
/// </summary>
public class ConfigurableWindowHelper
{
    public static void SourceInitialized(ConfigurableWindowWrapper wrapper)
    {
        if (wrapper != null)
        {
            wrapper.w.WindowState = wrapper._settings.WindowState;
        }
    }
    public static void RenderSizeChanged(ConfigurableWindowWrapper wrapper)
    {
        if (wrapper != null)
        {
            if (wrapper._isLoaded && wrapper.w.WindowState == WindowState.Normal)
            {
                wrapper._settings.WindowSize = wrapper.w.RenderSize;
            }
        }
    }
}