#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class ControlHelper
{


    public static Size GetMinimumHeightMinimumWidth(UIElement uie)
    {
        return GetMinimumHeightMinimumWidth(uie, ControlsHelperValues.SizePositiveInfinity);
    }

    public static Size GetMinimumHeightMinimumWidth(UIElement uie, Size windowSize)
    {
        uie.Measure(windowSize);
        var desiredSize = uie.DesiredSize;

        return desiredSize;
    }

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