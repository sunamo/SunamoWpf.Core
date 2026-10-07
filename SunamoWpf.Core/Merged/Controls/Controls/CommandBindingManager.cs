#define ASYNC
namespace SunamoWpf.Controls.Controls;

public class CommandBindingManager
{
    public static CommandBinding AddAndGetCommandBinding(Window window, RoutedCommand routedCommand, CanExecuteRoutedEventHandler canExecuteHandler, ExecutedRoutedEventHandler executedRoutedEventHandler)
    {
        CommandBinding commandBinding = new CommandBinding(routedCommand, executedRoutedEventHandler, canExecuteHandler);
        window.CommandBindings.Add(commandBinding);
        return commandBinding;
    }
}