#define ASYNC
namespace SunamoWpf.Controls.Helpers.Controls;

public class ContextMenuHelper
{
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