#define ASYNC
namespace SunamoWpf.Controls.Helpers.ControlsWithGet;

public partial class ActionButtonHelper{ 
/// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold 
    /// </summary>
    /// <param name = "tooltip"></param>
    /// <param name = "imagePath"></param>
    public static ActionButton<T> Get<T>(ControlInitData controlInitData)
    {
        ActionButton<T> button = new ActionButton<T>(controlInitData.action, (T)controlInitData.tag);
        ControlHelper.SetForeground(button, controlInitData.foreground);
        button.Content = ContentControlHelper.GetContent(controlInitData);
        if (controlInitData.OnClick != null)
        {
            button.Click += controlInitData.OnClick;
        }

        button.Tag = controlInitData.tag;
        button.ToolTip = controlInitData.tooltip;
        return button;
    }
}