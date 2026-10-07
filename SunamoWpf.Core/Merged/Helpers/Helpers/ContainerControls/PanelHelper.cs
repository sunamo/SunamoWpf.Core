#define ASYNC
namespace SunamoWpf.Helpers.ContainerControls;

public partial class PanelHelper
{
    public static List<UIElement> GetThisAndRecursiveAllSubUIElements(UIElement element)
    {
        List<UIElement> result = new List<UIElement>();
        result.Add(element);

        foreach (UIElement item in Childrens(element))
        {
            GetThisAndRecursiveAllSubUIElements(element, result);
        }
        return result;
    }

    /// <summary>
    /// because every of structure is other innered, is stupidity have own method for get content control without closer determination
    /// </summary>
    /// <param name="panel"></param>
    public static object ContentOfFirstChild(Panel panel)
    {
        var first = panel.Children;
        if (first == null)
        {
            return null;
        }
        var controls = VisualTreeHelpers.FindDescendents<ContentControl>(panel);
        return controls;
    }

    private static IList Childrens(UIElement maybePanel)
    {
        if (maybePanel != null)
        {
            if (maybePanel is ContentControl)
            {
                ContentControl contentControl = (ContentControl)maybePanel;
                // Will check for Panel
                return Childrens(contentControl.Content as UIElement);
            }

            else if (maybePanel is Panel)
            {
                return ((Panel)maybePanel).Children;
            }
        }

        return new System.Collections.Generic.List<object>();
    }

    /// <param name="element"></param>
    /// <param name="result"></param>
    private static void GetThisAndRecursiveAllSubUIElements(UIElement element, List<UIElement> result)
    {
        result.Add(element);


        foreach (UIElement item in Childrens(element))
        {
            GetThisAndRecursiveAllSubUIElements(item, result);
        }
    }

    private static void GetThisAndRecursiveAllSubUIElements<T>(UIElement element, List<T> result) where T : class
    {
        // Cant compare with ==, but check for parent classes. 
        // In most cases I will search for UIElement, Control etc. and nothing will found
        if (RH.IsOrIsDeriveFromBaseClass(element.GetType(), typeof(T)))
        {
            result.Add(element as T);
        }

        foreach (UIElement item in Childrens(element))
        {
            GetThisAndRecursiveAllSubUIElements(item, result);
        }
    }

    public static List<T> GetRecursiveAllSubUIElementsOfType<T>(UIElement control) where T : class
    {
        List<T> result = new List<T>();
        foreach (UIElement item in Childrens(control))
        {
            GetThisAndRecursiveAllSubUIElements<T>(item, result);
        }
        return result;
    }


}