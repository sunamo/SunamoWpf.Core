namespace SunamoWpf.Core._sunamo;

internal static partial class FrameworkElementExtensions{ 
public static double ActualHeight(this FrameworkElement frameworkElement)
    {
        if (frameworkElement == null)
        {
            return 0;
        }

        return frameworkElement.ActualHeight;
    }
}
