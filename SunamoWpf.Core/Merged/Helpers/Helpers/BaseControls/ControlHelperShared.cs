#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class ControlHelper{
    public static readonly Size SizePositiveInfinity = new Size(double.PositiveInfinity, double.PositiveInfinity);
    public static void SetForeground(Control control, Brush foreground)
    {
        if (foreground != null)
        {
            control.Foreground = foreground;
        }
    }
public static Size ActualInnerSize(ContentControl control)
    {
        

        var frameworkElement = control.Content as FrameworkElement;
        return new Size(frameworkElement.ActualWidth, frameworkElement.ActualHeight);
    }
    


}