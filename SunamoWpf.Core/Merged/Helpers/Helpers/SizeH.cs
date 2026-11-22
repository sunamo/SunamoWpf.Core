#define ASYNC
namespace SunamoWpf.Helpers;

/// <summary>
/// Represents the size h type.
/// </summary>
public class SizeH
{
    static Type type = typeof(SizeH);

    /// <summary>
    /// Divide.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="div">The div.</param>
    /// <returns>The divide result.</returns>
    public static Size Divide(Size size, double div)
    {
        return new Size(size.Width / div, size.Height / div);
    }

    /// <summary>
    /// Multiply.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="mul">The mul.</param>
    /// <returns>The multiply result.</returns>
    public static Size Multiply(Size size, double mul)
    {
        return new Size(size.Width * mul, size.Height * mul);
    }

    /// <summary>
    /// Multiply.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="dpiXPrinter">The dpi x printer.</param>
    /// <param name="dpiYPrinter">The dpi y printer.</param>
    /// <returns>The multiply result.</returns>
    public static Size Multiply(Size size, int dpiXPrinter, int dpiYPrinter)
    {
        return new Size(size.Width * dpiXPrinter, size.Height * dpiYPrinter);
    }

    /// <summary>
    /// Shring under.
    /// </summary>
    /// <param name="init2">The init 2.</param>
    /// <param name="max2">The max 2.</param>
    /// <returns>The shring under result.</returns>
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

    /// <summary>
    /// At least one dimension of first larger than second.
    /// </summary>
    /// <param name="init2">The init 2.</param>
    /// <param name="max2">The max 2.</param>
    /// <param name="allMustBeLower">The all must be lower.</param>
    /// <returns>The at least one dimension of first larger than second result.</returns>
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

    /// <summary>
    /// Cast size.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>The cast size result.</returns>
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

    /// <summary>
    /// One dimension of first larger than second.
    /// </summary>
    /// <param name="renderSize">The render size.</param>
    /// <param name="maxSize">The max size.</param>
    /// <returns>The one dimension of first larger than second result.</returns>
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

    /// <summary>
    /// Enlarge under.
    /// </summary>
    /// <param name="init2">The init 2.</param>
    /// <param name="max2">The max 2.</param>
    /// <returns>The enlarge under result.</returns>
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