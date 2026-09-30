#define ASYNC
namespace SunamoWpf.Controls.Helpers.ControlsWithGet;

public partial class SuMenuItemHelper{ 
    /// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold 
    /// </summary>
    /// <param name="header"></param>
    /// <param name="clickHandler"></param>
    public static SuMenuItem Get(ControlInitData d)
    {
        SuMenuItem mi = new SuMenuItem();
        mi.IsCheckable = d.checkable;
        mi.IsChecked = d.isChecked;
        if (d.foreground != null)
        {
            mi.Foreground = d.foreground;
        }
        if (d.OnClick != null)
        {
            mi.Click += d.OnClick;
        }
        if (d.list != null)
        {
            foreach (var item in d.list)
            {
                mi.Items.Add(Get((ControlInitData)item));
            }
        }
        mi.Tag = d.tag;
        mi.ToolTip = d.tooltip;
        d.addPadding = 20;
        // into Header I cant insert StackPanel from ContentControlHelper.GetContent( d);, because then is no show
        //mi.Header = d.text;
        mi.Header = ContentControlHelper.GetContent(d);
        return mi;
    }
}