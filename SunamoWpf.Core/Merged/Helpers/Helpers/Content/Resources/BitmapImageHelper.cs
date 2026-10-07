#define ASYNC
namespace SunamoWpf.Helpers.Content.Resources;

/// <summary>
/// Posloupnost je BitmapImage (sealed) -> BitmapSource (abstract) -> ImageSource (abstract)
/// </summary>
public static partial class BitmapImageHelper
{
    public static BitmapImage MsAppx(string relPath)
    {
        BitmapImage bitmapImage = new BitmapImage(new Uri(ImageHelper.protocol + relPath, UriKind.Absolute));
        return bitmapImage;
    }
    /// <summary>
    /// Do A1 se vkládá člen výčtu AppPics2.TS()
    /// Přípona se doplní automaticky na .png
    /// Používá se tehdy, když je obrázek v nějaké specifické složce(ne e nebo d) nebo když je přímo v rootu
    /// </summary>
    /// <param name = "appPic2"></param>
    public static BitmapImage MsAppxI(string appPic2)
    {
        BitmapImage bitmapImage = new BitmapImage(new Uri(ImageHelper.protocol + "i/" + appPic2 + ".png"));
        return bitmapImage;
    }
    public static BitmapImage MsAppx(bool disabled, AppPics appPic)
    {
        string cesta = "";
        if (disabled)
        {
            cesta = "//d/";
        }
        else
        {
            cesta = "//e/";
        }
        cesta += appPic.ToString() + ".png";
        return MsAppx(cesta);
    }
    public static BitmapSource Path(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return null;
        }
        return Uri(new Uri(path, UriKind.Absolute));
    }
    public static BitmapSource Uri(Uri uri)
    {
        BitmapImage bitmapImage = null;
        try
        {
            bitmapImage = new BitmapImage(uri);
        }
        catch (Exception)
        {
            // Image was damaged
        }
        return bitmapImage;
    }
    public static BitmapImage MsAppxRoot(string path)
    {
        return new BitmapImage(new Uri(ImageHelper.protocolRoot + path, UriKind.Absolute));
    }
}