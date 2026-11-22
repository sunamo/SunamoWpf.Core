#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class ControlHelper{
    /// <summary>
    /// The size positive infinity.
    /// </summary>
    public static readonly Size SizePositiveInfinity = new Size(double.PositiveInfinity, double.PositiveInfinity);
    /// <summary>
    /// Set foreground.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <param name="foreground">The foreground.</param>
    public static void SetForeground(Control control, Brush foreground)
    {
        if (foreground != null)
        {
            control.Foreground = foreground;
        }
    }
/// <summary>
/// Actual inner size.
/// </summary>
/// <param name="control">The control.</param>
/// <returns>The actual inner size result.</returns>
public static Size ActualInnerSize(ContentControl control)
    {
        

        var frameworkElement = control.Content as FrameworkElement;
        return new Size(frameworkElement.ActualWidth, frameworkElement.ActualHeight);
    }
    


}