#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public class LabelHelper
{
    static Type type = typeof(LabelHelper);

    public static Label Get(ControlInitData controlInitData)
    {
        Label label = new Label();
        ControlHelper.SetForeground(label, controlInitData.foreground);
        label.Content = ContentControlHelper.GetContent(controlInitData);
        label.Foreground = controlInitData.foreground;
        if (controlInitData.OnClick != null)
        {
            ThrowEx.IsNotNull("d.OnClick", controlInitData.OnClick);
            //vr.MouseDown += d.OnClick;
        }
        label.Tag = controlInitData.tag;
        label.ToolTip = controlInitData.tooltip;
        return label;
    }
}