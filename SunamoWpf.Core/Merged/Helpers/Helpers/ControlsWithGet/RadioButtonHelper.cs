#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public class RadioButtonHelper
{
    /// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="name"></param>
    public static RadioButton Get(ControlInitData controlInitData)
    {
        RadioButton chb = new RadioButton();
        ControlHelper.SetForeground(chb, controlInitData.foreground);
        chb.GroupName = controlInitData.group;
        chb.Content = ContentControlHelper.GetContent(controlInitData);
        chb.IsChecked = controlInitData.isChecked;
        chb.Checked += controlInitData.OnClick;
        if (controlInitData.tag == null)
        {
            chb.Tag = ControlNameGenerator.GetSeries(chb.GetType());
        }
        else
        {
            chb.Tag = controlInitData.tag;
        }
        chb.ToolTip = controlInitData.tooltip;
        return chb;
    }
}