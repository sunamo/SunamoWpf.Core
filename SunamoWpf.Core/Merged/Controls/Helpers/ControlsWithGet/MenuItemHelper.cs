#define ASYNC
namespace SunamoWpf.Controls.Helpers.ControlsWithGet;

/// <summary>
/// Represents the su menu item helper type.
/// </summary>
public partial class SuMenuItemHelper
{
    SuMenuItem mi = null;
    /// <summary>
    /// Initializes a new instance of the su menu item helper class.
    /// </summary>
    /// <param name="menuItem">The menu item.</param>
    public SuMenuItemHelper(SuMenuItem menuItem)
    {
        this.mi = menuItem;
    }
    /// <summary>
    /// Add values of enum as items.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <param name="eventHandler">The event handler.</param>
    public void AddValuesOfEnumAsItems(Array values, RoutedEventHandler eventHandler)
    {
        foreach (object item in values)
        {
            SuMenuItem tsmi = new SuMenuItem();
            tsmi.Header = item.ToString();
            tsmi.Tag = item;
            tsmi.Click += eventHandler;
            mi.Items.Add(tsmi);
        }
    }
    /// <summary>
    /// A2 was onClick
    /// A4 was tag
    /// </summary>
    /// <param name="controlInitData"></param>
    public static SuMenuItem GetCheckable(ControlInitData controlInitData)
    {
        controlInitData.checkable = true;
        return Get(controlInitData);
    }
    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="miInClipboard">The mi in clipboard.</param>
    public static void Remove(SuMenuItem miInClipboard)
    {
        var itemsControl = (ItemsControl) miInClipboard.Parent;
        itemsControl.Items.Remove(miInClipboard);
    }
}