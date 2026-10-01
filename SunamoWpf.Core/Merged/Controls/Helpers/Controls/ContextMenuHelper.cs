#define ASYNC
namespace SunamoWpf.Controls.Helpers.Controls;

public class ContextMenuHelper
{
    public static SuMenuItem GetSuMenuItemWithName(ContextMenu cm, string name)
    {
        int i = 0;
        while (true)
        {
            if (i == cm.Items.Count)
            {
                break;
            }
            object o = cm.Items.GetItemAt(i);
            if (o is SuMenuItem)
            {
                SuMenuItem vr = o as SuMenuItem;
                if (vr.Name == name)
                {
                    return vr;
                }
            }
            i++;
        }
        return null;
    }
    public static ContextMenu FindContextMenu(DependencyObject depObj, DependencyProperty ContextMenuProperty)
    {
        ContextMenu cm = depObj.GetValue(ContextMenuProperty) as ContextMenu;
        if (cm != null)
            return cm;
        int children = VisualTreeHelper.GetChildrenCount(depObj);
        for (int i = 0; i < children; i++)
        {
            cm = FindContextMenu(VisualTreeHelper.GetChild(depObj, i), ContextMenuProperty);
            if (cm != null)
                return cm;
        }
        return null;
    }
}