namespace SunamoWpf.SunamoDebugging;

public class FrameworkElementDebug
{
    public static void ActualSize(FrameworkElement frameworkElement)
    {
        if (frameworkElement == null)
        {
            return;
        }

        Debug.WriteLine($"{frameworkElement.Name} ActualHeight: {frameworkElement.ActualHeight}");
        Debug.WriteLine($"{frameworkElement.Name} ActualWidth: {frameworkElement.ActualWidth}");
        Debug.WriteLine($"{frameworkElement.Name} DesiredSize: {frameworkElement.DesiredSize}");
        Debug.WriteLine($"{frameworkElement.Name} RenderSize: {frameworkElement.RenderSize}");
        Debug.WriteLine($"{frameworkElement.Name} Height: {frameworkElement.Height}");
        Debug.WriteLine($"{frameworkElement.Name} Width: {frameworkElement.Width}");
        Debug.WriteLine($"{frameworkElement.Name} MaxHeight: {frameworkElement.MaxHeight}");
        Debug.WriteLine($"{frameworkElement.Name} MaxWidth: {frameworkElement.MaxWidth}");
        Debug.WriteLine($"{frameworkElement.Name} MinHeight: {frameworkElement.MinHeight}");
        Debug.WriteLine($"{frameworkElement.Name} MinWidth: {frameworkElement.MinWidth}");

    }
}