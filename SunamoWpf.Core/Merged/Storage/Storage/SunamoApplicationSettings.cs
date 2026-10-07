#define ASYNC
namespace SunamoWpf.Storage;

public class SunamoApplicationSettings
{
    public static Dictionary<FrameworkElement, TUListWpf<FrameworkElement, DependencyProperty>> savedElement = new Dictionary<FrameworkElement, TUListWpf<FrameworkElement, DependencyProperty>>();
    public static void AddChildrenFrom(FrameworkElement frameworkElement)
    {
        if (frameworkElement is Panel)
        {
            Panel panel = frameworkElement as Panel;
            //The settings property 'sp.System.Windows.Controls.StackPanel' is of a non-compatible type.'
            //AddToSavedElements(panel);
            foreach (FrameworkElement item in panel.Children)
            {
                AddChildrenFrom(item);
            }
        }
        else
        {
            AddToSavedElements(frameworkElement);
            if (frameworkElement is Window)
            {
                Window panel = frameworkElement as Window;
                AddChildrenFrom(panel.Content as FrameworkElement);
            }
        }
    }
    private static void AddToSavedElements(FrameworkElement frameworkElement)
    {
        TUListWpf<FrameworkElement, DependencyProperty> list = new TUListWpf<FrameworkElement, DependencyProperty>();
        // U TextBox mi to vrátilo 2, ačkoliv má jich mnohem vic i bez base class
        var depencies = DependencyObjectHelper.GetDependencyProperties(frameworkElement);
        var attached = DependencyObjectHelper.GetAttachedProperties(frameworkElement);
        foreach (var item in depencies)
        {
            list.Add(TUWpf<FrameworkElement, DependencyProperty>.Get(frameworkElement, item));
        }
        foreach (var item in attached)
        {
            list.Add(TUWpf<FrameworkElement, DependencyProperty>.Get(frameworkElement, item));
        }
        savedElement.Add(frameworkElement, list);
    }
}