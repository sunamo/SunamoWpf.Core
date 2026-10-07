#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class ContentControlHelper
{
    public static object Content(CheckBox checkBox)
    {
        var content = WpfApp.cd.Invoke(() => checkBox.Content);
        return content;
    }
    public static string ExtractContent(object value)
    {
        var sp2 = (StackPanel)value;
        var result = ExtractContent(sp2);
        return result;
    }

    public static string ExtractContent(StackPanel stackPanel)
    {
        /*
Je zde ta věc že 
         */

        StringBuilder stringBuilder = new StringBuilder();

        WpfApp.cd.Invoke(() =>
        {
            foreach (var item in stackPanel.Children)
            {
                //if (item is StackPanel)
                //{
                var sp2 = item as TextBlock;
                if (sp2 != null)
                {
                    if (AwesomeFontControls.IsFamilyFontFontAwesome(sp2.FontFamily))
                    {
                        continue;
                    }
                    stringBuilder.Append(sp2.Text);
                }

                //}
            }
        }, System.Windows.Threading.DispatcherPriority.ContextIdle);
        return stringBuilder.ToString();
    }

    public static async Task<StackPanel> GetContent(ControlInitData controlInitData)
    {
        var img = controlInitData.imagePath;
        var text = controlInitData.text;
        bool isImg = img != null;
        bool isText = text != null;

        if (!isText)
        {
            isText = controlInitData.xlfKey != null;
            text = Translate.FromKey(controlInitData.xlfKey);
        }

        StackPanel stackPanel = new StackPanel();
        stackPanel.Orientation = Orientation.Horizontal;
        //10*2 padding
        stackPanel.Height = controlInitData.imageHeight + controlInitData.addPadding;
        if (isImg && isText)
        {
            var tbHeight = await AddImg(img, stackPanel, controlInitData.imageWidth, controlInitData.imageHeight);
            AddTextBlock(text, stackPanel, tbHeight);
        }
        else if (isImg)
        {
            AddImg(img, stackPanel, controlInitData.imageWidth, controlInitData.imageHeight).RunSynchronously();
        }
        else if (isText)
        {
            AddTextBlock(text, stackPanel);
        }

        return stackPanel;
    }



    /// <summary>
    /// Return height which 
    /// </summary>
    /// <param name="img"></param>
    /// <param name="stackPanel"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    private static async Task<double> AddImg(object img, StackPanel stackPanel, double width, double height)
    {
        bool isAwesome = false;
        var imgS = img.ToString();

        if (img.GetType() == Types.tString)
        {
            if (imgS.Length == 1)
            {
                var first = imgS[0];
                if (first >= AwesomeFontControls.low && first <= AwesomeFontControls.high)
                {
                    isAwesome = true;
                }
            }
        }

        if (isAwesome)
        {
            TextBlock textBlock = new TextBlock();

            textBlock.FontSize = height;
            textBlock.Padding = new System.Windows.Thickness(10);

            stackPanel.Height = height + textBlock.Padding.Top + textBlock.Padding.Bottom;
            stackPanel.Width = width;

            await AwesomeFontControls.SetAwesomeFontSymbol(textBlock, imgS);
            stackPanel.Children.Add(textBlock);
        }
        else
        {
            var img2 = ImageHelperDesktop.Get(img);
            img2.Margin = new System.Windows.Thickness(10);

            stackPanel.Children.Add(img2);
        }

        var size = AwesomeFontControls.ReturnFontSizeForTextNextToAwesomeIconWithSize(stackPanel.Height);
        return size;
    }

    private static void AddTextBlock(string text, StackPanel stackPanel, double tbHeight = double.NaN)
    {
        var textBlock = TextBlockHelper.Get(new ControlInitData { text = text });
        if (!double.IsNaN(tbHeight))
        {
            textBlock.FontSize = tbHeight;
        }

        // Must be vertical alignment
        textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;

        stackPanel.Children.Add(textBlock);
    }
}