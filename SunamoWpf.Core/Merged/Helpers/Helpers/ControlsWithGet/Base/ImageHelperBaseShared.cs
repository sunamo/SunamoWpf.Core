#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet.Base;

public  abstract partial class ImageHelperBase<ImageSource, ImageControl>
{
    public abstract ImageControl ReturnImage(ImageSource imageSource);
    public abstract ImageControl ReturnImage(ImageSource imageSource, double width, double height);
}