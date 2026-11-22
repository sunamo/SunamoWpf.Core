#define ASYNC
namespace SunamoWpf.Helpers.ControlsWithGet.Base;

public  abstract partial class ImageHelperBase<ImageSource, ImageControl>
{
    /// <summary>
    /// Return image.
    /// </summary>
    /// <param name="imageSource">The image source.</param>
    /// <returns>The return image result.</returns>
    public abstract ImageControl ReturnImage(ImageSource imageSource);
    /// <summary>
    /// Return image.
    /// </summary>
    /// <param name="imageSource">The image source.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The return image result.</returns>
    public abstract ImageControl ReturnImage(ImageSource imageSource, double width, double height);
}