#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public static partial class ButtonHelper
{

    public static void SaveTransparentImageAsContent(ContentControl button, System.Windows.Media.Color color, string imageRelPath)
    {
        BitmapSource bitmapSource = BitmapImageHelper.MsAppx(imageRelPath);
        SaveTransparentImageAsContent(button, color, bitmapSource);
    }

    /// <summary>
    /// Not working, but it was maybe because color is not exactly as was specified
    /// Not use Lunapic or my code to create favicon. Always download image from net
    /// </summary>
    /// <param name="button"></param>
    /// <param name="color"></param>
    /// <param name="bitmapSource"></param>
    public static void SaveTransparentImageAsContent(ContentControl button, System.Windows.Media.Color color, BitmapSource bitmapSource)
    {
        bitmapSource = PicturesDesktop.MakeTransparentWindowsFormsButton(bitmapSource, color);
        Image image = ImageHelper.ReturnImage(bitmapSource);
        image.Width = 20;
        image.Height = 20;
        button.Content = image;
    }
}