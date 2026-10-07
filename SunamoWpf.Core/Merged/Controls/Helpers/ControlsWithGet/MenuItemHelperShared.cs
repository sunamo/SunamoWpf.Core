#define ASYNC
namespace SunamoWpf.Controls.Helpers.ControlsWithGet;

public partial class SuMenuItemHelper{ 
    /// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold 
    /// </summary>
    /// <param name="header"></param>
    /// <param name="clickHandler"></param>
    public static SuMenuItem Get(ControlInitData controlInitData)
    {
        SuMenuItem menuItem = new SuMenuItem();
        menuItem.IsCheckable = controlInitData.checkable;
        menuItem.IsChecked = controlInitData.isChecked;
        if (controlInitData.foreground != null)
        {
            menuItem.Foreground = controlInitData.foreground;
        }
        if (controlInitData.OnClick != null)
        {
            menuItem.Click += controlInitData.OnClick;
        }
        if (controlInitData.list != null)
        {
            foreach (var item in controlInitData.list)
            {
                menuItem.Items.Add(Get((ControlInitData)item));
            }
        }
        menuItem.Tag = controlInitData.tag;
        menuItem.ToolTip = controlInitData.tooltip;
        controlInitData.addPadding = 20;
        // into Header I cant insert StackPanel from ContentControlHelper.GetContent( d);, because then is no show
        //mi.Header = d.text;
        menuItem.Header = ContentControlHelper.GetContent(controlInitData);
        return menuItem;
    }
}