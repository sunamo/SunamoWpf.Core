#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public static partial class ButtonHelper{ 


/// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold 
    /// </summary>
    /// <param name="tooltip"></param>
    /// <param name="imagePath"></param>
    public static Button Get(ControlInitData controlInitData)
    {
        Button button = new Button();
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

    public static void PerformClick(Button btnEnter)
    {
        btnEnter.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
    }
}