#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

/// <summary>
/// Represents the control helper type.
/// </summary>
public partial class ControlHelper
{


    /// <summary>
    /// Get minimum height minimum width.
    /// </summary>
    /// <param name="uie">The uie.</param>
    /// <returns>The get minimum height minimum width result.</returns>
    public static Size GetMinimumHeightMinimumWidth(UIElement uie)
    {
        return GetMinimumHeightMinimumWidth(uie, ControlsHelperValues.SizePositiveInfinity);
    }

    /// <summary>
    /// Get minimum height minimum width.
    /// </summary>
    /// <param name="uie">The uie.</param>
    /// <param name="windowSize">The window size.</param>
    /// <returns>The get minimum height minimum width result.</returns>
    public static Size GetMinimumHeightMinimumWidth(UIElement uie, Size windowSize)
    {
        uie.Measure(windowSize);
        var desiredSize = uie.DesiredSize;

        return desiredSize;
    }

    /// <summary>
    /// Get on center.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <param name="child">The child.</param>
    /// <returns>The get on center result.</returns>
    public static Point GetOnCenter(Size parent, Size child)
    {
        Point result = new Point();
        if (parent.Width > child.Width)
        {
            result.X = ((parent.Width - child.Width) / 2d);
        }
        else if (parent.Width == child.Width)
        {
            result.X = 0;
        }
        else
        {
            result.X = 0;
        }

        if (parent.Height > child.Height)
        {
            result.Y = (parent.Height - child.Height) / 2d;
        }
        else if (parent.Height == child.Height)
        {
            result.Y = 0;
        }
        else
        {
            result.Y = 0;
        }

        return result;
    }

    /// <summary>
    /// Switch border.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <param name="borderData">The border data.</param>
    public static void SwitchBorder(Control control, BorderData borderData)
    {
        if (control != null)
        {
            var thickness = control.BorderThickness;
            if (!CA.IsAllTheSame<double>(NumConsts.zeroDouble, [thickness.Bottom, thickness.Left, thickness.Right, thickness.Top]))
            {
                borderData = BorderData.None;
            }

            control.BorderThickness = borderData.BorderThickness;
            control.BorderBrush = borderData.BorderBrush;
        }
    }

}