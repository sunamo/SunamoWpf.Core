#define ASYNC
namespace SunamoWpf.Controls.Controls;

/// <summary>
/// Represents the command binding manager type.
/// </summary>
public class CommandBindingManager
{
    /// <summary>
    /// Add and get command binding.
    /// </summary>
    /// <param name="window">The window.</param>
    /// <param name="routedCommand">The routed command.</param>
    /// <param name="canExecuteHandler">The can execute handler.</param>
    /// <param name="executedRoutedEventHandler">The executed routed event handler.</param>
    /// <returns>The add and get command binding result.</returns>
    public static CommandBinding AddAndGetCommandBinding(Window window, RoutedCommand routedCommand, CanExecuteRoutedEventHandler canExecuteHandler, ExecutedRoutedEventHandler executedRoutedEventHandler)
    {
        CommandBinding commandBinding = new CommandBinding(routedCommand, executedRoutedEventHandler, canExecuteHandler);
        window.CommandBindings.Add(commandBinding);
        return commandBinding;
    }
}