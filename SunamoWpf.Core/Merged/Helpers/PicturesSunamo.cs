#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the pictures sunamo type.
/// </summary>
public partial class PicturesSunamo
{
    /// <summary>
    /// Image resize.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The image resize result.</returns>
    public static System.Drawing.Image ImageResize(System.Drawing.Image image, int width, int height)
    {
        var bmp = new System.Drawing.Bitmap(width, height);
        using (var graphics = System.Drawing.Graphics.FromImage(bmp))
        {
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, 0, 0, width, height);
        }
        return bmp;
    }

    /// <summary>
    /// Get pictures files.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The get pictures files result.</returns>
    public static List<string> GetPicturesFiles(string path)
    {
        var masc = string.Join(";", AllLists.BasicImageExtensions);
        return Directory.GetFiles(path, masc, SearchOption.TopDirectoryOnly).ToList();
    }


}