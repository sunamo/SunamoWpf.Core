#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public partial class ImageHelperDesktop : ImageHelperBase<ImageSource, Image>
{
    public override Image MsAppx(string relPath)
    {
        BitmapSource bitmapSource = new BitmapImage(new Uri(ImageHelper.protocol + relPath));
        return ReturnImage(bitmapSource);
    }
    public override Image MsAppx(bool disabled, AppPics appPic)
    {
        ///Subfolder/ResourceFile.xaml
        return ReturnImage(BitmapImageHelper.MsAppx(disabled, appPic));
    }
    public override Image MsAppxI(string appPic2)
    {
        BitmapSource bitmapSource = new BitmapImage(new Uri(ImageHelper.protocol + "i/" + appPic2 + ".png"));
        return ReturnImage(bitmapSource);
    }
}