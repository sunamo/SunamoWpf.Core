#define ASYNC
namespace SunamoWpf.Controls.Helpers.Controls;

/// <summary>
/// Represents the context menu helper type.
/// </summary>
public class ContextMenuHelper
{
    /// <summary>
    /// Get su menu item with name.
    /// </summary>
    /// <param name="contextMenu">The context menu.</param>
    /// <param name="name">The name.</param>
    /// <returns>The get su menu item with name result.</returns>
    public static SuMenuItem GetSuMenuItemWithName(ContextMenu contextMenu, string name)
    {
        int index = 0;
        while (true)
        {
            if (index == contextMenu.Items.Count)
            {
                break;
            }
            object item = contextMenu.Items.GetItemAt(index);
            if (item is SuMenuItem)
            {
                SuMenuItem menuItem = item as SuMenuItem;
                if (menuItem.Name == name)
                {
                    return menuItem;
                }
            }
            index++;
        }
        return null;
    }
    /// <summary>
    /// Find context menu.
    /// </summary>
    /// <param name="depObj">The dep obj.</param>
    /// <param name="ContextMenuProperty">The context menu property.</param>
    /// <returns>The find context menu result.</returns>
    public static ContextMenu FindContextMenu(DependencyObject depObj, DependencyProperty ContextMenuProperty)
    {
        ContextMenu contextMenu = depObj.GetValue(ContextMenuProperty) as ContextMenu;
        if (contextMenu != null)
            return contextMenu;
        int children = VisualTreeHelper.GetChildrenCount(depObj);
        for (int index = 0; index < children; index++)
        {
            contextMenu = FindContextMenu(VisualTreeHelper.GetChild(depObj, index), ContextMenuProperty);
            if (contextMenu != null)
                return contextMenu;
        }
        return null;
    }
}