#define ASYNC
namespace SunamoWpf.Controls.Helpers.ControlsWithGet;

public partial class SuMenuItemHelper
{
    SuMenuItem mi = null;
    public SuMenuItemHelper(SuMenuItem menuItem)
    {
        this.mi = menuItem;
    }
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
    public static void Remove(SuMenuItem miInClipboard)
    {
        var itemsControl = (ItemsControl) miInClipboard.Parent;
        itemsControl.Items.Remove(miInClipboard);
    }
}