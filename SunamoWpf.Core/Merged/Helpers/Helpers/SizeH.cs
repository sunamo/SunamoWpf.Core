#define ASYNC
namespace SunamoWpf.Helpers;

public class SizeH
{
    static Type type = typeof(SizeH);

    public static Size Divide(Size size, double div)
    {
        return new Size(size.Width / div, size.Height / div);
    }

    public static Size Multiply(Size size, double mul)
    {
        return new Size(size.Width * mul, size.Height * mul);
    }

    public static Size Multiply(Size size, int dpiXPrinter, int dpiYPrinter)
    {
        return new Size(size.Width * dpiXPrinter, size.Height * dpiYPrinter);
    }

    public static SunamoSize ShringUnder(object init2, object max2)
    {
        var init = CastSize(init2);
        var max = CastSize(max2);


        if (AtLeastOneDimensionOfFirstLargerThanSecond(init, max, false))
        {
            while (true)
            {
                init.Width *= 0.95;
                init.Height *= 0.95;

                if (AtLeastOneDimensionOfFirstLargerThanSecond(init, max, true))
                {
                    break;
                }
            }
        }

        return init;
    }

    public static bool AtLeastOneDimensionOfFirstLargerThanSecond(object init2, object max2, bool allMustBeLower)
    {
        var init = CastSize(init2);
        var max = CastSize(max2);

        var exceedsWidth = init.Width > max.Width;
        var exceedsHeight = init.Height > max.Height;

        if (init.IsNegativeOrZero())
        {
            // In if is often break, return true to quit from cycle
            return true;
        }

        if (allMustBeLower)
        {
            var fits = !exceedsWidth && !exceedsHeight;

            return fits;
        }

        return exceedsWidth || exceedsHeight;
    }

    public static SunamoSize CastSize(object input)
    {
        var type = input.GetType();
        if (type == typeof(DesktopSize))
        {
            return ((DesktopSize)input).ToSunamoSize();
        }
        else if (type == typeof(SunamoSize))
        {
            return (SunamoSize)input;
        }
        else if (type == typeof(System.Windows.Size))
        {
            //var c = (System.Windows.Size)s;
            //return c.ToSunamo();

            return null;
        }
        //else if (t == typeof(System.Drawing.Size))
        //{
        //    var c = (System.Drawing.Size)s;
        //    return c.ToSunamo();
        //}
        //else if (t == typeof(System.Drawing.SizeF))
        //{
        //    var c = (System.Drawing.SizeF)s;
        //    return c.ToSunamo();
        //}
        else
        {
            ThrowEx.NotImplementedCase(type);
        }
        return null;
    }

    public static bool OneDimensionOfFirstLargerThanSecond(object renderSize, object maxSize)
    {
        var renderSizeCast = CastSize(renderSize);
        var maxSizeCast = CastSize(maxSize);

        bool isWider = renderSizeCast.Width > maxSizeCast.Width;
        bool isHigher = renderSizeCast.Height > maxSizeCast.Height;

        if ((isWider && !isHigher) || !isWider && isHigher)
        {
            return true;
        }
        return false;
    }

    public static SunamoSize EnlargeUnder(object init2, object max2)
    {
        var init = CastSize(init2);
        var max = CastSize(max2);

        if (AtLeastOneDimensionOfFirstLargerThanSecond(max, init, false))
        {
            while (true)
            {
                init.Width *= 1.05;
                init.Height *= 1.05;

                if (AtLeastOneDimensionOfFirstLargerThanSecond(init, max, false))
                {
                    // Init is in both direction larger
                    init.Width *= 0.95;
                    init.Height *= 0.95;

                    break;
                }
            }
        }
        return init;
    }
}