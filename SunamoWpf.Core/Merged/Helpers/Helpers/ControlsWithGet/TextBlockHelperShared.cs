#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public partial class TextBlockHelper{

    static Type type = typeof(TextBlockHelper);

    /// <summary>
    /// tag is not needed, value is obtained through []
    /// Tag here is mainly for comment what data control hold 
    /// </summary>
    /// <param name="text"></param>
    public static TextBlock Get(ControlInitData controlInitData)
    {
        TextBlock textBlock = new TextBlock();

        // TextBlock is not derived from Control, so have own property Foreground
        TextBlockHelper.SetForeground(textBlock, controlInitData.foreground);

        if (controlInitData.imagePath != null)
        {
            ThrowEx.IsNotNull("d.imagePath", controlInitData.imagePath);
        }

        textBlock.Tag = controlInitData.tag;
        textBlock.ToolTip = controlInitData.tooltip;
        textBlock.Text = controlInitData.text;

        return textBlock;
    }

    public static void SetText(TextBlock lblStatusDownload, string status)
    {
        if (lblStatusDownload != null)
        {
            // Must be invoke because after that I immediately load it on ListBox
            lblStatusDownload.Dispatcher.Invoke(() =>
            {
                lblStatusDownload.Text = status;
            }

            );
        }
    }

    /// <summary>
    /// A1 can be TextBlock or any object
    /// </summary>
    /// <param name = "value"></param>
    public static string TextOrToString(object value)
    {
        if (value is TextBlock)
        {
            var tb2 = (TextBlock)value;
            return tb2.Text;
        }

        return value.ToString();
    }

    public static void SetForeground(TextBlock textBlock, Brush foreground)
    {
        if (foreground != null)
        {
            textBlock.Foreground = foreground;
        }
    }
}