#define ASYNC
namespace SunamoWpf.Helpers.ContainerControls;

public partial class PanelHelper
{
    public static UIElementCollection Children(StackPanel key, Dispatcher dispatcher)
    {
        //WpfApp.cd

        var children = dispatcher.Invoke(() => key.Children, DispatcherPriority.ContextIdle);
        return children;

    }
}