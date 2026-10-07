#define ASYNC
namespace SunamoWpf.Helpers;

public partial class PicturesDesktop
{
    static Type type = typeof(PicturesDesktop);
    /// <summary>
    /// A1 must be BitmapSource, not ImageSource
    /// A2 was originally Colors.Magenta
    /// </summary>
    /// <param name="bitmapSource"></param>
    public static BitmapSource MakeTransparentWindowsFormsButton(BitmapSource bitmapSource, System.Windows.Media.Color transparentColor)
    {
        return MakeTransparentBitmap(bitmapSource, transparentColor);
    }
    //public static Bitmap BitmapImage2Bitmap(BitmapSource bitmapImage)
    //      {
    //          using (MemoryStream outStream = new MemoryStream())
    //          {
    //              BitmapEncoder enc = new BmpBitmapEncoder();
    //              enc.Frames.Add(BitmapFrame.Create(bitmapImage));
    //              enc.Save(outStream);
    //              System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
    //              // return bitmap; <-- leads to problems, stream is closed/closing ...
    //              return new Bitmap(bitmap);
    //          }
    //      }
    #region Mono
    #region Již v CreateW10AppGraphics - několik PlaceToCenter metod
    /// <summary>
    /// Funguje naprosto správně, už nic neměnit
    /// 11-2-2019 nsn
    /// Not use Lunapic or my code to create favicon. Always download image from net
    /// </summary>
    /// <param name="bitmapSource"></param>
    /// <param name="trans"></param>
    /// <param name="white2"></param>
    private static WriteableBitmap MakeWriteableBitmapTransparentAllOther(BitmapSource bitmapSource, PixelColorWpf trans, PixelColorWpf white2)
    {
        white2.Alpha = 255;
        PixelColorWpf pxZero = new PixelColorWpf() { Alpha = 0, Red = 0, Green = 0, Blue = 0 };
        WriteableBitmap writeableBitmap = new WriteableBitmap(bitmapSource);
        var pxs = BitmapSourceHelper.GetPixels(bitmapSource);
        var first = pxs[0, 0];
        int count = 0;
        int nt2 = 0;
        for (int index = 0; index < pxs.GetLength(0); index++)
        {
            for (int y = 0; y < pxs.GetLength(1); y++)
            {
                var pxsi = pxs[index, y];
                bool isFirstColor = ColorHelper.IsColorSame(first, pxsi);
                bool isTransparent = pxsi.Alpha < 254;
                if (isFirstColor)
                {
                    pxs[index, y] = trans;
                }
                else
                {
                    //////////DebugLogger.Instance.Write(pxsi.Alpha + "-" + pxsi.Red + "-" + pxsi.Green + "-" + pxsi.Blue);
                    if (isTransparent)
                    {
                        count++;
                        pxs[index, y] = white2;
                    }
                    else
                    {
                        nt2++;
                        pxs[index, y] = trans;
                    }
                }
            }
        }
        BitmapSourceHelper.PutPixels(writeableBitmap, pxs, 0, 0);
        return writeableBitmap;
    }
    private static BitmapSource CreateBitmapSourceAndDrawOpacity(int pixelWidth, int pixelHeight, BitmapSource bmp2, double y, double x, bool useA3PixelSize)
    {
        DrawingVisual drawingVisual = new DrawingVisual();
        var drawingContext = drawingVisual.RenderOpen();
        //dc.DrawRectangle(new SolidColorBrush(System.Windows.Media.Colors.Red), new System.Windows.Media.Pen(new SolidColorBrush(System.Windows.Media.Colors.Red), 50), new Rect(x, y, bmp2.Width, bmp2.Height));
        drawingContext.PushOpacity(1);
        double width = bmp2.Width;
        double height = bmp2.Height;
        if (useA3PixelSize)
        {
            width = bmp2.PixelWidth;
            height = bmp2.PixelHeight;
        }
        drawingContext.DrawImage(bmp2, new Rect(x, y, width, height));
        ////dc.Pop();
        drawingContext.Close();
        RenderTargetBitmap bmp = new RenderTargetBitmap(pixelWidth, pixelHeight, 96, 96, PixelFormats.Default);
        bmp.Render(drawingVisual);
        return bmp;
    }
    private static BitmapSource CreateBitmapSource(double width, double height, double minimalWidthPadding, double minimalHeightPadding, string arg, BitmapSource img2, bool useAtA1PixelSize = false)
    {
        BitmapSource bitmapSource;
        //int stride = (int)width / 8;
        int stride = (int)width * ((img2.Format.BitsPerPixel + 7) / 8);
        byte[] pixels = new byte[(int)height * stride];
        BitmapSource img = null;
        img = BitmapSource.Create((int)(width), (int)(height), 96, 96, PixelFormats.Bgra32, BitmapPalettes.WebPaletteTransparent, pixels, stride);
        var bitmap = img;
        if (minimalHeightPadding <= 0 && minimalWidthPadding <= 0)
        {
            bitmapSource = PicturesDesktop.PlaceToCenter(bitmap, bitmap.Width, bitmap.Height, false, 0, 0, arg, img2, true);
        }
        else
        {
            bitmapSource = PicturesDesktop.PlaceToCenter(bitmap, bitmap.Width, bitmap.Height, false, minimalWidthPadding / 2, minimalHeightPadding / 2, arg, img2, useAtA1PixelSize);
        }
        //return PlaceToCenterExactly(img, args, width, height, i, temp, writeToConsole, minimalWidthPadding, minimalHeightPadding);
        return bitmapSource;
    }
    #region PlaceToCenter metody - využívající WPF třídu BitmapSource kterou vrací
    private static BitmapSource PlaceToCenter(BitmapSource img, double width, double height, bool writeToConsole, double minimalWidthPadding, double minimalHeightPadding, string arg, BitmapSource bmp2, bool useAtA1PixelSize = false)
    {
        string fnOri = FS.GetFileName(arg);
        string ext = "";
        if (PicturesSunamo.GetImageFormatFromExtension1(fnOri, out ext))
        {
            double bitmapHeight = bmp2.Height;
            double bitmapWidth = bmp2.Width;
            if (useAtA1PixelSize)
            {
                bitmapHeight = bmp2.PixelHeight;
                bitmapWidth = bmp2.PixelWidth;
            }
            double y = (height - bitmapHeight);
            double x = (width - bitmapWidth);
            // Prvně si já ověřím zda obrázek je delší než šířka aby to nebylo kostkované
            if (y < 1 || x < 1)
            {
                return CreateBitmapSourceAndDrawOpacity(bmp2.PixelWidth, bmp2.PixelHeight, bmp2, 0, 0, true);
            }
            if (y < 0)
            {
                y = 0;
            }
            if (x < 0)
            {
                x = 0;
            }
            #region MyRegion
            double imageWidth = 0;
            double imageHeight = 0;
            imageWidth = img.Width;
            imageHeight = img.Height;
            while (imageWidth > width && imageHeight > height)
            {
                imageWidth *= .9f;
                imageHeight *= .9f;
            }
            if (width <= height)
            {
                double minimalHeightPadding2 = (minimalHeightPadding * 2);
                double minimalWidthPadding2 = (minimalWidthPadding * 2);
                if (minimalHeightPadding2 + bmp2.Height <= (img.Height - 1))
                {
                    y = ((img.Height - bmp2.Height) / 2);
                }
                if (minimalWidthPadding2 + bmp2.Width <= (img.Width - 1))
                {
                    x = ((img.Width - bmp2.Width) / 2);
                }
            }
            else
            {
            }
            x /= 2;
            y /= 2;
            if (writeToConsole)
            {
                //InitApp.TemplateLogger.SuccessfullyResized(FS.GetFileName(arg));
            }
            return CreateBitmapSourceAndDrawOpacity(img.PixelWidth, img.PixelHeight, bmp2, y, x, useAtA1PixelSize);
            #endregion
        }
        else
        {
            ThrowEx.FileHasExtensionNotParseAbleToImageFormat(fnOri);
        }
        return null;
    }

    public static BitmapSource PlaceToCenterFixedPercentSize(string path, string imagePath, double targetWidth, double targetHeight, double percentWidthIconOfImage, double percentHeightIconOfImage, PixelColorWpf bgPixelColor, PixelColorWpf fgPixelColor/*, PixelColorWpf definitelyFgPixelColor*/)
    {
        var bitmap = imagePath;
        double width = targetWidth;
        double height = targetHeight;
        double paddingLeftRight = 0;
        double paddingTopBottom = 0;
        BitmapSource result = null;
        if (!path.Contains("unplated"))
        {
            double newWidth = width * percentWidthIconOfImage / 100;
            paddingLeftRight = (width - newWidth) / 2;
            double newHeight = height * percentHeightIconOfImage / 100;
            paddingTopBottom = (height - newHeight) / 2;
            if (path.Contains("targetsize-16"))
            {
                //vr = PicturesShared.PlaceToCenterExactly(width, height, false, paddingLeftRight, paddingTopBottom, bi, ratioW, ratioH, true);
                result = PicturesDesktop.ImageResize(imagePath, width, height, /*PicturesSunamo.GetImageFormatsFromExtension(bi),*/ true);
                result = CreateBitmapSource(result.PixelWidth, result.PixelHeight, paddingLeftRight, paddingTopBottom, imagePath, result, true);
            }
            else if (path.Contains("targetsize"))
            {
                result = PicturesDesktop.PlaceToCenterExactly(width, height, /*false,*/ paddingLeftRight, paddingTopBottom, imagePath, /*ratioW, ratioH,*/ false);
            }
            else
            {
                result = PicturesDesktop.PlaceToCenterExactly(width, height, /*false,*/ paddingLeftRight, paddingTopBottom, imagePath, /*ratioW, ratioH,*/ false);
            }
        }
        else
        {
            result = PicturesDesktop.ImageResize(imagePath, width, height, /*PicturesSunamo.GetImageFormatsFromExtension(bi),*/ true);
            result = CreateBitmapSource(result.PixelWidth, result.PixelHeight, 0, 0, imagePath, result);
        }
        var wb2 = result;
        if (!false)
        {
            wb2 = MakeWriteableBitmapTransparentAllOther(result, bgPixelColor, fgPixelColor);
            //}
        }
        return wb2;
    }
    /// <summary>
    /// Umístí obrázek na střed s paddingem skoro přesným(maximálně o pár px vyšším)
    /// Do A7 a A8 zadávej hodnoty pro levý/pravý a vrchní/spodnní padding, nikoliv ale jejich součet, metoda si je sama vynásobí
    /// </summary>
    /// <param name="img"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="i"></param>
    /// <param name="finalPath"></param>
    /// <param name="writeToConsole"></param>
    /// <param name="minimalWidthPadding"></param>
    /// <param name="minimalHeightPadding"></param>
    /// <param name="args"></param>
    public static BitmapSource PlaceToCenterExactly(double width, double height, /*bool writeToConsole,*/ double minimalWidthPadding, double minimalHeightPadding, string arg2, /*double ratioW, double ratioH*/ bool useAtA1PixelSize = false)
    {
        double ratioW; double ratioH;
        BitmapImage bi2 = new BitmapImage(new Uri(arg2));
        ratioW = bi2.PixelWidth / bi2.Width;
        ratioH = bi2.PixelHeight / bi2.Height;
        BitmapImageWithPath arg = new BitmapImageWithPath(arg2, bi2);
        // OK, já teď potřebuji zjistit na jakou velikost mám tento obrázek zmenšit
        string fnOri = ""; // FS.GetFileName(args[i]);
        double minWidthImage = width - (minimalWidthPadding);
        double minHeightImage = height - (minimalHeightPadding);
        double newWidth = width;
        double newHeight = height;
        double innerWidth = arg.image.Width;
        double innerHeight = arg.image.Height;
        var img2 = PicturesDesktop.ImageResize(arg.path, minWidthImage, minHeightImage, /*PicturesSunamo.GetImageFormatsFromExtension(arg.path),*/ useAtA1PixelSize);
        BitmapSource bitmapSource = null;
        //bi = img2;
        if (true && img2 != null)
        {
            bitmapSource = CreateBitmapSource(width, height, minimalWidthPadding, minimalHeightPadding, arg.path, img2, useAtA1PixelSize);
        }
        else
        {
            ThrowEx.FileHasExtensionNotParseableToImageFormat(fnOri);
        }
        return bitmapSource;
    }
    #endregion
    #endregion
    #endregion
    #region Mono
    /// <summary>
    /// 11-2-2019 nsn
    /// Not use Lunapic or my code to create favicon. Always download image from net
    /// </summary>
    /// <param name="bitmapSource"></param>
    /// <param name="trans"></param>
    /// <param name="white2"></param>
    private static WriteableBitmap MakeWriteableBitmapTransparentFill(BitmapSource bitmapSource, PixelColorWpf white2)
    {
        white2.Alpha = 255;
        //PixelColor px = white2;
        var trans = new PixelColorWpf() { Alpha = 0, Red = 255, Green = 255, Blue = 255 };
        WriteableBitmap writeableBitmap = new WriteableBitmap(bitmapSource);
        var pxs = BitmapSourceHelper.GetPixels(bitmapSource);
        var first = pxs[0, 0];
        for (int index = 0; index < pxs.GetLength(0); index++)
        {
            for (int y = 0; y < pxs.GetLength(1); y++)
            {
                var pxsi = pxs[index, y];
                if (pxsi.Red != 0 || pxsi.Blue != 0 || pxsi.Green != 0)
                {
                    if (pxsi.Red == 255 || pxsi.Blue == 255 || pxsi.Green == 255)
                    {
                        if (pxsi.Alpha == 0)
                        {
                            pxs[index, y] = trans;
                        }
                        else
                        {
                            pxs[index, y] = white2;
                        }
                        //}
                    }
                    else
                    {
                        pxs[index, y] = trans;
                    }
                }
                else
                {
                    if (pxsi.Alpha == 0)
                    {
                        pxs[index, y] = trans;
                    }
                    else
                    {
                        pxs[index, y] = white2;
                    }
                }
            }
        }
        BitmapSourceHelper.PutPixels(writeableBitmap, pxs, 0, 0);
        return writeableBitmap;
    }
    /// <summary>
    /// 11-2-2019 nsn
    /// Not use Lunapic or my code to create favicon. Always download image from net
    /// </summary>
    /// <param name="bitmapSource"></param>
    /// <param name="trans"></param>
    /// <param name="white2"></param>
    private static WriteableBitmap MakeWriteableBitmapTransparent(BitmapSource bitmapSource, PixelColorWpf white2)
    {
        white2.Alpha = 255;
        //PixelColor px = white2;
        var trans = new PixelColorWpf() { Alpha = 0, Red = 255, Green = 255, Blue = 255 };
        WriteableBitmap writeableBitmap = new WriteableBitmap(bitmapSource);
        var pxs = BitmapSourceHelper.GetPixels(bitmapSource);
        var first = pxs[0, 0];
        for (int index = 0; index < pxs.GetLength(0); index++)
        {
            for (int y = 0; y < pxs.GetLength(1); y++)
            {
                var pxsi = pxs[index, y];
                if (pxsi.Red != 0 || pxsi.Blue != 0 || pxsi.Green != 0)
                {
                    if (pxsi.Red == 255 || pxsi.Blue == 255 || pxsi.Green == 255)
                    {
                        if (pxsi.Alpha == 0)
                        {
                            pxs[index, y] = white2;
                        }
                        else
                        {
                            pxs[index, y] = trans;
                        }
                        //}
                    }
                    else
                    {
                        //pxs[i, y] = white2;
                    }
                }
                else
                {
                    if (pxsi.Alpha == 0)
                    {
                        pxs[index, y] = trans;
                    }
                    else
                    {
                        pxs[index, y] = trans;
                    }
                }
            }
        }
        BitmapSourceHelper.PutPixels(writeableBitmap, pxs, 0, 0);
        return writeableBitmap;
    }
    /// <summary>
    /// A7 zda 
    /// </summary>
    /// <param name="imageSource"></param>
    /// <param name="decodePixelWidth"></param>
    /// <param name="decodePixelHeight"></param>
    /// <param name="paddingLeftRight"></param>
    /// <param name="paddingTopBottom"></param>
    /// <param name="imgsf"></param>
    public static BitmapSource ImageResize(string imageSource, double decodePixelWidth, double decodePixelHeight, /*double paddingLeftRight, double paddingTopBottom,*/  bool a2IsPixelWidth = false)
    {
        #region Zmenšuje načerno
        #endregion
        #region Při menších rozlišení zmenšuje špatně
        #endregion
        #region Zmenšuje do obrázku velikosti 1x1px
        BitmapImage ims = new BitmapImage(new Uri(imageSource));
        double scaleX, scaleY;
        if (a2IsPixelWidth)
        {
            scaleX = (decodePixelWidth / (double)ims.PixelWidth) / 1;
            scaleY = (decodePixelHeight / (double)ims.PixelHeight) / 1;
        }
        else
        {
            scaleX = decodePixelWidth / (double)ims.Width;
            scaleY = decodePixelHeight / (double)ims.Height;
        }
        ScaleTransform scaleTransform = new ScaleTransform();
        double rate = Math.Min(scaleX, scaleY);
        scaleTransform.ScaleX = rate;
        scaleTransform.ScaleY = rate;
        TransformedBitmap transformedBitmap = new TransformedBitmap(ims, scaleTransform);
        return transformedBitmap;
        #endregion
    }
    #endregion
}