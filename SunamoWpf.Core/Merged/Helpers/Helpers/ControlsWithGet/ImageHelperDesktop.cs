#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

/// <summary>
/// Represents the image helper desktop type.
/// </summary>
public partial class ImageHelperDesktop : ImageHelperBase<ImageSource, Image>
{
    /// <summary>
    /// Ms appx.
    /// </summary>
    /// <param name="relPath">The rel path.</param>
    /// <returns>The ms appx result.</returns>
    public override Image MsAppx(string relPath)
    {
        BitmapSource bitmapSource = new BitmapImage(new Uri(ImageHelper.protocol + relPath));
        return ReturnImage(bitmapSource);
    }
    /// <summary>
    /// Ms appx.
    /// </summary>
    /// <param name="disabled">The disabled.</param>
    /// <param name="appPic">The app pic.</param>
    /// <returns>The ms appx result.</returns>
    public override Image MsAppx(bool disabled, AppPics appPic)
    {
        ///Subfolder/ResourceFile.xaml
        return ReturnImage(BitmapImageHelper.MsAppx(disabled, appPic));
    }
    /// <summary>
    /// Ms appx i.
    /// </summary>
    /// <param name="appPic2">The app pic 2.</param>
    /// <returns>The ms appx i result.</returns>
    public override Image MsAppxI(string appPic2)
    {
        BitmapSource bitmapSource = new BitmapImage(new Uri(ImageHelper.protocol + "i/" + appPic2 + ".png"));
        return ReturnImage(bitmapSource);
    }
}