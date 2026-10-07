#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public class VisualHelper
{
    /// <summary>
    /// A1 je Control jen proto abych mohl zjistit DPI, pokud bys ho zjistil z jiného controlu můžeš do A1 použít UIElement
    /// </summary>
    /// <param name="uiElement"></param>
    /// <param name="resolution"></param>
    //private static RenderTargetBitmap ConvertToBitmap(FrameworkElement uiElement, double resolutionX, double resolutionY)
    //{
    //    double dpi = WindowsDisplaySettings.getScalingFactor();
    //    var scaleX = resolutionX / dpi;
    //    var scaleY = resolutionY / dpi;
    //    scaleX = dpi;
    //    scaleY = dpi;

    //    uiElement.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
    //    var sz = uiElement.DesiredSize;
    //    var rect = new Rect(sz);
    //    uiElement.Arrange(rect);

    //    var bmp = new RenderTargetBitmap((int)(scaleX * (rect.Width)), (int)(scaleY * (rect.Height)), scaleX * dpi, scaleY * dpi, PixelFormats.Default);
    //    //ModifyPosition(uiElement);
    //    bmp.Render(uiElement);
    //    return bmp;
    //}

    //public static byte[] ConvertToJpegBytes(FrameworkElement uiElement, double resolutionX, double resolutionY)
    //{
    //    var jpegString = CreateJpeg(ConvertToBitmap(uiElement, resolutionX, resolutionY));
    //    MemoryStream ms = null;
    //    ms = new MemoryStream();

    //    var streamWriter = new StreamWriter(ms, Encoding.UTF8);

    //    streamWriter.Write(jpegString);

    //    ms.Seek(0, SeekOrigin.Begin);
    //    var vr = ms.ToArray();
    //    streamWriter.Close();
    //    return vr;
    //}

    private static void ModifyPositionBack(FrameworkElement frameworkElement)
    {
        /// remeasure a size smaller than need, wpf will
        /// rearrange it to the original position
        frameworkElement.Measure(new Size());
    }

    private static void ModifyPosition(FrameworkElement frameworkElement)
    {
        /// get the size of the visual with margin
        Size size = new Size(
            frameworkElement.ActualWidth +
            frameworkElement.Margin.Left + frameworkElement.Margin.Right,
            frameworkElement.ActualHeight +
            frameworkElement.Margin.Top + frameworkElement.Margin.Bottom);

        /// measure the visual with new size
        frameworkElement.Measure(size);

        /// arrange the visual to align parent with (0,0)
        frameworkElement.Arrange(new Rect(
            -frameworkElement.Margin.Left, -frameworkElement.Margin.Top,
            size.Width, size.Height));
    }

    private static string CreateJpeg(RenderTargetBitmap bitmap)
    {
        var jpeg = new JpegBitmapEncoder();
        jpeg.Frames.Add(BitmapFrame.Create(bitmap));
        string result;

        using (var memoryStream = new MemoryStream())
        {
            jpeg.Save(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            using (var streamReader = new StreamReader(memoryStream, Encoding.UTF8))
            {
                result = streamReader.ReadToEnd();
                streamReader.Close();
            }

            memoryStream.Close();
        }

        return result;
    }

    public static byte[] ConvertVisualToBytes(FrameworkElement maybePanel, FrameworkElement element, Size forceSizeTo)
    {
        /// get bound of the visual
        //Rect b = VisualTreeHelper.GetDescendantBounds(v);
        Rect bounds = BoundsRelativeTo(element, maybePanel);

        if (forceSizeTo != null)
        {
            bounds.Size = forceSizeTo;
        }

        /// new a RenderTargetBitmap with actual size of c
        RenderTargetBitmap renderTarget = new RenderTargetBitmap(
            (int)bounds.Width, (int)bounds.Height,
            96, 96, PixelFormats.Pbgra32);

        /// render visual
        ModifyPosition(element);
        renderTarget.Render(element);
        ModifyPositionBack(element);

        /// new a JpegBitmapEncoder and add r into it 
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(renderTarget));

        MemoryStream memoryStream = new MemoryStream();
        /// new a FileStream to write the image file
        //FileStream s = new FileStream(f, FileMode.OpenOrCreate, FileAccess.Write);
        encoder.Save(memoryStream);
        var bytes = memoryStream.ToArray();
        memoryStream.Close();
        return bytes;
    }

    /// <summary>
    /// A1 je objekt u kterého chci zjistit Rect
    /// A2 je jeho hlavní kontainer(většinou nějaký panel)
    /// </summary>
    /// <param name="element"></param>
    /// <param name="relativeTo"></param>
    public static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
    {
        return
          element.TransformToVisual(relativeTo)
                 .TransformBounds(LayoutInformation.GetLayoutSlot(element));
    }

    static DrawingVisual ModifyToDrawingVisual(Visual visual)
    {
        Rect bounds = VisualTreeHelper.GetDescendantBounds(visual);
        /// new a drawing visual and get its context
        DrawingVisual drawingVisual = new DrawingVisual();
        DrawingContext drawingContext = drawingVisual.RenderOpen();

        /// generate a visual brush by input, and paint
        VisualBrush visualBrush = new VisualBrush(visual);
        drawingContext.DrawRectangle(visualBrush, null, bounds);
        drawingContext.Close();

        return drawingVisual;
    }
}