#define ASYNC
namespace SunamoWpf.Helpers.Content.Resources;

public static partial class BitmapImageHelper
{
    public static BitmapImage PathToBitmapImage(string path)
    {
        ; return UriToBitmapImage(new Uri(path, UriKind.Absolute));
    }

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

    public static BitmapImage Resize(BitmapImage source, int width, int height)
    {
        source.BeginInit();
        source.DecodePixelHeight = width;
        source.DecodePixelWidth = height;
        source.EndInit();
        return source;
    }

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