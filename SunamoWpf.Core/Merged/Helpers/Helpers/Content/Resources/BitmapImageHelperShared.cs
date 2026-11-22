#define ASYNC
namespace SunamoWpf.Helpers.Content.Resources;

public static partial class BitmapImageHelper
{
    /// <summary>
    /// Path to bitmap image.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The path to bitmap image result.</returns>
    public static BitmapImage PathToBitmapImage(string path)
    {
        ; return UriToBitmapImage(new Uri(path, UriKind.Absolute));
    }

    /// <summary>
    /// Uri to bitmap image.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <returns>The uri to bitmap image result.</returns>
    public static BitmapImage UriToBitmapImage(Uri uri)
    {
        BitmapImage bitmapImage = new BitmapImage(uri);
        return bitmapImage;
    }

    #region Convert between System.Windows and System.Drawing - same name in all helper classes
    /// <summary>
    /// Converts a System.Drawing image to a WPF BitmapImage via an in-memory PNG.
    /// </summary>
    public static BitmapImage Bitmap2BitmapImage(System.Drawing.Image bitmap)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Position = 0;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }

    /// <summary>
    /// Resize.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The resize result.</returns>
    public static BitmapImage Resize(BitmapImage source, int width, int height)
    {
        source.BeginInit();
        source.DecodePixelHeight = width;
        source.DecodePixelWidth = height;
        source.EndInit();
        return source;
    }

    /// <summary>
    /// Resize.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="rate">The rate.</param>
    /// <param name="init">The init.</param>
    /// <returns>The resize result.</returns>
    public static BitmapImage Resize(BitmapImage source, int rate, bool init)
    {
        if (init)
        {
            source.BeginInit();
        }

        source.DecodePixelHeight = rate;
        source.DecodePixelWidth = rate;
        if (init)
        {
            source.EndInit();
        }

        return source;
    }

    /// <summary>
    /// Save.
    /// </summary>
    /// <param name="renderTarget">The render target.</param>
    /// <param name="path">The path.</param>
    public static void Save(BitmapSource renderTarget, string path)
    {
        PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
        bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
        using (Stream stm = File.Create(path))
        {
            FS.CreateUpfoldersPsysicallyUnlessThere(path);
            bitmapEncoder.Save(stm);

            // Cant be, otherwise could be visible on another screenshot
            //WpfLogger.Success( "File written to " + fn);
        }
    }
    #endregion
}