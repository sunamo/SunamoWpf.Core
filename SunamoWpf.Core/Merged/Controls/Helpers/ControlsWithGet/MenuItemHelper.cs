#define ASYNC
namespace SunamoWpf.Controls.Helpers.ControlsWithGet;

public partial class SuMenuItemHelper
{
    SuMenuItem mi = null;
    public SuMenuItemHelper(SuMenuItem mi)
    {
        this.mi = mi;
    }
    public void AddValuesOfEnumAsItems(Array bs, RoutedEventHandler eh)
    {
        foreach (object item in bs)
        {
            SuMenuItem tsmi = new SuMenuItem();
            tsmi.Header = item.ToString();
            tsmi.Tag = item;
            tsmi.Click += eh;
            mi.Items.Add(tsmi);
        }
    }
    /// <summary>
    /// A2 was onClick
    /// A4 was tag
    /// </summary>
    /// <param name="d"></param>
    public static SuMenuItem GetCheckable(ControlInitData d)
    {
        d.checkable = true;
        return Get(d);
    }
    public static void Remove(SuMenuItem miInClipboard)
    {
        var ic = (ItemsControl) miInClipboard.Parent;
        ic.Items.Remove(miInClipboard);
    }
}