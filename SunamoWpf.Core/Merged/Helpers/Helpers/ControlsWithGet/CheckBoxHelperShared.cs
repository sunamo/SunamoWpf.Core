#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public partial class CheckBoxHelper
{

    public static bool IsChecked(CheckBox checkBox)
    {
        var isChecked = WpfApp.cd.Invoke(() => checkBox.IsChecked);
        return isChecked.GetValueOrDefault();
    }

    /// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold 
    /// </summary>
    /// <param name="text"></param>
    public static CheckBox Get(ControlInitData controlInitData)
    {
        CheckBox chb = new CheckBox();
        ControlHelper.SetForeground(chb, controlInitData.foreground);
        chb.Content = ContentControlHelper.GetContent(controlInitData);
        if (controlInitData.OnClick != null)
        {
            chb.Click += controlInitData.OnClick;
        }
        chb.Tag = ControlNameGenerator.GetSeries(chb.GetType());
        chb.ToolTip = controlInitData.tooltip;
        return chb;
    }
}