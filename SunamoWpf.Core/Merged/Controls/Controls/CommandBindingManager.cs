#define ASYNC
namespace SunamoWpf.Controls.Controls;

public class CommandBindingManager
{
    public static CommandBinding AddAndGetCommandBinding(Window w, RoutedCommand routedCommand, CanExecuteRoutedEventHandler canExecuteHandler, ExecutedRoutedEventHandler executedRoutedEventHandler)
    {
        CommandBinding cb = new CommandBinding(routedCommand, executedRoutedEventHandler, canExecuteHandler);
        w.CommandBindings.Add(cb);
        return cb;
    }
}