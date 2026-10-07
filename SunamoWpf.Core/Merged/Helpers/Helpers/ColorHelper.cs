#define ASYNC
namespace SunamoWpf.Helpers;

public class ColorHelperDesktop
{
    #region Mono
    public static bool IsColorLight(Color clr)
    {
        // Bude 0 pro černou barvu, 254.99999999999997 pro bílou
        double luminance = .222 * clr.R + .707 * clr.G + .071 * clr.B;
        return luminance > 128;
    }



    public static System.Drawing.Color ConvertColorFromWindowsMediaToDrawing(Color color)
    {
        return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
    }

    public static bool IsColorSimilar(System.Windows.Media.Color first, System.Windows.Media.Color second, int threshold = 50)
    {
        int redDifference = (int)first.R - second.R;
        int greenDifference = (int)first.G - second.G;
        int blueDifference = (int)first.B - second.B;
        return (redDifference * redDifference + greenDifference * greenDifference + blueDifference * blueDifference) <= threshold * threshold;
    }

    public static PixelColorWpf PixelColorFromDrawingColor(System.Windows.Media.Color color, byte? alpha)
    {
        if (alpha == null)
        {
            alpha = color.A;
        }
        PixelColorWpf white2 = new PixelColorWpf() { Alpha = alpha.Value, Red = color.R, Green = color.G, Blue = color.B };
        return white2;
    }
    #endregion

    #region Mono
    public static WriteableBitmap SwapColor(BitmapSource bitmapSource, PixelColorWpf bgPixelColor, PixelColorWpf fgPixelColorFg, PixelColorWpf definitelyFgPixelColor)
    {

        var balckZero = DrawingColorHelper.PixelColorFromDrawingColor(System.Drawing.Color.Black, 0);
        WriteableBitmap writeableBitmap = new WriteableBitmap(bitmapSource);
        var pxs = BitmapSourceHelper.GetPixels(bitmapSource);
        var first = pxs[0, 0];
        for (int index = 0; index < pxs.GetLength(0); index++)
        {
            for (int y = 0; y < pxs.GetLength(1); y++)
            {

                var pxsi = pxs[index, y];
#if DEBUG
                //////////DebugLogger.Instance.Write(pxsi.Alpha + "-" + pxsi.Red + "-" + pxsi.Green + "-" + pxsi.Blue);
#endif

                bool isBackground = ColorHelper.IsColorSame(bgPixelColor, pxsi) || ColorHelper.IsColorSame(balckZero, pxsi);
                bool isDefinitelyForeground = ColorHelper.IsColorSame(definitelyFgPixelColor, pxsi);
                bool isForeground = ColorHelper.IsColorSame(fgPixelColorFg, pxsi);
                if (!isBackground)
                {
                    if (isDefinitelyForeground || isForeground)
                    {


                        if (isForeground)
                        {
                            pxs[index, y] = definitelyFgPixelColor;
                        }
                        else
                        {
                            pxs[index, y] = fgPixelColorFg;
                        }
                    }
                }

            }
        }

        BitmapSourceHelper.PutPixels(writeableBitmap, pxs, 0, 0);
        return writeableBitmap;
    }

    public static WriteableBitmap ReplaceAlpha(BitmapSource bitmapSource/*, PixelColorWpf bgPixelColor*/)
    {
        PixelColorWpf balckZero = DrawingColorHelper.PixelColorFromDrawingColor(System.Drawing.Color.Black, 0);
        WriteableBitmap writeableBitmap = new WriteableBitmap(bitmapSource);
        var pxs = BitmapSourceHelper.GetPixels(bitmapSource);
        var first = pxs[0, 0];
        for (int index = 0; index < pxs.GetLength(0); index++)
        {
            for (int y = 0; y < pxs.GetLength(1); y++)
            {

                var pxsi = pxs[index, y];
                if (pxsi.Alpha < 255)
                {

                    pxs[index, y].Alpha = 0;
                }

            }
        }

        BitmapSourceHelper.PutPixels(writeableBitmap, pxs, 0, 0);
        return writeableBitmap;
    }
    #endregion
}