#define ASYNC
namespace SunamoWpf.ConfigurableWindow;

/// <summary>
/// 
/// </summary>
public class ConfigurableWindowInstance : Window, IConfigurableWindow
{
    public ApplicationDataContainer data { get; set; }
    public ConfigurableWindowWrapper configurableWindowWrapper { get; set; }
    /// <summary>
    /// Data cant be static
    /// </summary>
    /// <param name="data"></param>
    public ConfigurableWindowInstance()
    {
        //this.data = data;
        SourceInitialized += ConfigurableWindow_SourceInitialized;
    }
    public IConfigurableWindowSettings CreateSettings()
    {
        return new WindowConfigSettings(this, data);
    }
    /// <summary>
    /// Don't copy, is not needed
    /// Has normal event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    private void ConfigurableWindow_SourceInitialized(object sender, EventArgs eventArgs)
    {
        ConfigurableWindowHelper.SourceInitialized(configurableWindowWrapper);
    }
    /// <summary>
    /// Must be due to save changed size of window
    /// Dont have normal event
    /// </summary>
    /// <param name="info"></param>
    protected override void OnRenderSizeChanged(SizeChangedInfo info)
    {
        base.OnRenderSizeChanged(info);
        if (configurableWindowWrapper != null)
        {
            if (configurableWindowWrapper._isLoaded && this.WindowState == WindowState.Normal)
            {
                configurableWindowWrapper._settings.WindowSize = this.RenderSize;
            }
            ConfigurableWindowHelper.RenderSizeChanged(configurableWindowWrapper);
        }
    }
}