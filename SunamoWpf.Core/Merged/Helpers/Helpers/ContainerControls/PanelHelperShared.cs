#define ASYNC
namespace SunamoWpf.Helpers.ContainerControls;

public partial class PanelHelper
{
    /// <summary>
    /// Children.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="dispatcher">The dispatcher.</param>
    /// <returns>The children result.</returns>
    public static UIElementCollection Children(StackPanel key, Dispatcher dispatcher)
    {
        //WpfApp.cd

        var children = dispatcher.Invoke(() => key.Children, DispatcherPriority.ContextIdle);
        return children;

    }
}