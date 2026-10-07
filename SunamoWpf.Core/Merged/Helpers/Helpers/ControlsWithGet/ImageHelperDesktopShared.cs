#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet;

public partial class ImageHelperDesktop : ImageHelperBase<ImageSource, Image>
{
    static Type type = typeof(ImageHelperDesktop);

public static Image Get(object imagePathOrBitmapImage)
    {
        var type = imagePathOrBitmapImage.GetType();
        BitmapImage bitmapImage = null;
        if (type == TypesDesktop.tBitmapImage)
        {
            bitmapImage = (BitmapImage)imagePathOrBitmapImage;
        }
        else if (type == Types.tString)
        {
            bitmapImage = BitmapImageHelper.PathToBitmapImage(imagePathOrBitmapImage.ToString());
        }
        else
        {
            ThrowEx.NotImplementedCase(type);
        }

        Image img = ImageHelper.ReturnImage(bitmapImage);
        return img;
    }

public override Image ReturnImage(ImageSource imageSource)
    {
        Image image = new Image();
        image.Stretch = Stretch.Uniform;
        image.Source = imageSource;
        return image;
    }
public override Image ReturnImage(ImageSource imageSource, double width, double height)
    {
        Image image = new Image();
        image.Stretch = Stretch.Uniform;
        image.Source = imageSource;
        image.Width = width;
        image.Height = height;
        return image;
    }
}