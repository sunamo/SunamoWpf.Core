#define ASYNC
namespace SunamoWpf.Helpers;

/// <summary>
/// Posloupnost je BitmapImage (sealed) -> BitmapSource (abstract) -> ImageSource (abstract)
/// </summary>
public static class BitmapSourceHelper
{
#if UNSAFE
  public static  unsafe static void CopyPixels(this BitmapSource source, PixelColor[,] pixels, int stride, int offset)
  {
    fixed(PixelColor* buffer = &pixels[0, 0])
      source.CopyPixels(
        new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
        (IntPtr)(buffer + offset),
        pixels.GetLength(0) * pixels.GetLength(1) * sizeof(PixelColor),
        stride);
  }
#else
    /// <summary>
    /// Copy pixels.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="pixels">The pixels.</param>
    /// <param name="stride">The stride.</param>
    /// <param name="offset">The offset.</param>
    public static void CopyPixels(this BitmapSource source, PixelColorWpf[,] pixels, int stride, int offset)
    {
        var height = source.PixelHeight;
        var width = source.PixelWidth;
        var pixelBytes = new byte[height * width * 4];
        source.CopyPixels(pixelBytes, stride, 0);
        int y0 = offset / width;
        int x0 = offset - width * y0;
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                pixels[x + x0, y + y0] = new PixelColorWpf
                {
                    Blue = pixelBytes[(y * width + x) * 4 + 0],
                    Green = pixelBytes[(y * width + x) * 4 + 1],
                    Red = pixelBytes[(y * width + x) * 4 + 2],
                    Alpha = pixelBytes[(y * width + x) * 4 + 3],
                };
    }
#endif
    /// <summary>
    /// Get pixels.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>The get pixels result.</returns>
    public static PixelColorWpf[,] GetPixels(BitmapSource source)
    {
        if (source.Format != PixelFormats.Bgra32)
            source = new FormatConvertedBitmap(source, PixelFormats.Bgra32, null, 0);
        int width = source.PixelWidth;
        int height = source.PixelHeight;
        byte[] byteArray = new byte[width * height * 4];
        //int nStride = (source.PixelWidth * source.Format.BitsPerPixel + 7) / 8;
        source.CopyPixels(byteArray, width * 4, 0);
        PixelColorWpf[,] result = new PixelColorWpf[width, height];
        var colorArray = new PixelColorWpf[byteArray.Length / 4];
        for (var index = 0; index < byteArray.Length; index += 4)
        {
            var color = new PixelColorWpf { Alpha = byteArray[index + 0], Red = byteArray[index + 1], Green = byteArray[index + 2], Blue = byteArray[index + 3] };
            colorArray[index / 4] = color;
        }
        result = new PixelColorWpf[0, 0]; //CA.OneDimensionArrayToTwoDirection<PixelColor>(colorArray, source.PixelWidth);
        return result;
    }
    /// <summary>
    /// Put pixels.
    /// </summary>
    /// <param name="bitmap">The bitmap.</param>
    /// <param name="pixels">The pixels.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public static void PutPixels(WriteableBitmap bitmap, PixelColorWpf[,] pixels, int x, int y)
    {
        int width = pixels.GetLength(1);
        int height = pixels.GetLength(0);
        bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * 4, x, y);
    }
}