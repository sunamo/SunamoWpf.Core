#define ASYNC
namespace SunamoWpf;

public partial class PicturesSunamo
{
    private static List<string> s_supportedExtensionForResize = new List<string> {
        "png", "jpg", "jpeg", "gif"
    };
    static Type type = typeof(PicturesSunamo);
    /// <summary>
    /// Vypočte optimální šířku v případě že obrázek je postaven na výšku.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="p_2"></param>
    /// <param name="p_3"></param>
    public static System.Windows.Size CalculateOptimalSizeHeight(int width, int height, int maxHeight)
    {
        System.Windows.Size size = new System.Windows.Size(width, height);
        int vyskaSloupce = maxHeight;
        if (height > vyskaSloupce)
        {
            size.Height = vyskaSloupce;
            // mohl by ses ještě rozhodovat jestli round, nebo floor, nebo ceil
            size.Width = vyskaSloupce * width / height;
        }
        return size;
    }
    /// <summary>
    /// Get image format from extension 1.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="ext">The ext.</param>
    /// <returns>The get image format from extension 1 result.</returns>
    public static bool GetImageFormatFromExtension1(string filePath, out string ext)
    {
        ext = Path.GetExtension(filePath).TrimStart('.').ToLower();
        if (PicturesSunamo.IsSupportedResizeForExtension(ext))
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Get image formats from extension.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The get image formats from extension result.</returns>
    public static ImageFormats GetImageFormatsFromExtension(string filePath)
    {
        string ext = Path.GetExtension(filePath).TrimStart('.').ToLower();
        return GetImageFormatsFromExtension2(ext);
    }
    private static bool IsSupportedResizeForExtension(string ext)
    {
        if (ext == "jpg")
        {
            ext = "jpeg";
        }
        for (int index = 0; index < s_supportedExtensionForResize.Count; index++)
        {
            if (s_supportedExtensionForResize[index] == ext)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Get image formats from extension 2.
    /// </summary>
    /// <param name="ext">The ext.</param>
    /// <returns>The get image formats from extension 2 result.</returns>
    public static ImageFormats GetImageFormatsFromExtension2(string ext)
    {
        if (ext == "")
        {
            return ImageFormats.None;
        }
        if (!IsSupportedResizeForExtension(ext))
        {
            return ImageFormats.None;
        }
        return (ImageFormats)Enum.Parse(typeof(ImageFormats), ext, true);
    }
    /// <summary>
    /// Calculate optimal size.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="maxWidth">The max width.</param>
    /// <returns>The calculate optimal size result.</returns>
    public static System.Windows.Size CalculateOptimalSize(int width, int height, int maxWidth)
    {
        return CalculateOptimalSizeWpf(width, height, maxWidth);
    }
    /// <summary>
    /// Calculate optimal size wpf.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="maxWidth">The max width.</param>
    /// <returns>The calculate optimal size wpf result.</returns>
    public static System.Windows.Size CalculateOptimalSizeWpf(double width, double height, int maxWidth)
    {
        System.Windows.Size size = new System.Windows.Size(width, height);
        int sirkaSloupce = maxWidth;
        if (width > sirkaSloupce)
        {
            size.Width = sirkaSloupce;
            // mohl by ses ještě rozhodovat jestli round, nebo floor, nebo ceil
            size.Height = sirkaSloupce * height / width;
        }
        return size;
    }
}