#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class FrameworkElementHelper
{
    static Type type = typeof(FrameworkElementHelper);
    public static object GetTagCheckBoxListUC(object sender)
    {
        var frameworkElement = (FrameworkElement)sender;
        var tag = frameworkElement.Tag;
        var elementTag = (FrameworkElementTag)tag;
        return elementTag.tagCheckBoxListUC;
    }
    public static int CountOfAncestor(FrameworkElement item)
    {
        var menuItem = item as MenuItem;
        int result = 0;
        while (true)
        {
            if (item.Parent == null)
            {
                break;
            }
            item = item.Parent as FrameworkElement;
            if (item == null)
            {
                break;
            }
            result++;
        }
        return result;
    }
    private static string HeaderOrName(FrameworkElement item)
    {
        var menuItem = item as MenuItem;
        if (menuItem != null)
        {
            if (menuItem.Name != null)
            {
                return menuItem.Name;
            }
            if (menuItem.Header != null)
            {
                return menuItem.Header.ToString();
            }
            return "(null)";
        }
        return "Not MI";
    }
    public static T CastTo<T>(FrameworkElement element) where T : class
    {
        T casted = default(T);
        //var casted2 = o as T;
        while (EqualityComparer<T>.Default.Equals(casted, default(T)))
        {
            if (element.Parent == null)
            {
                break;
            }
            element = (FrameworkElement)element.Parent;
            casted = element as T;
        }
        return casted;
    }
    public static Size GetMaxContentSize(FrameworkElement frameworkElement)
    {
        return new Size(frameworkElement.ActualWidth, frameworkElement.ActualHeight);
    }
    public static Size GetContentSize(FrameworkElement frameworkElement)
    {
        return new Size(frameworkElement.Width, frameworkElement.Height);
    }
    public static void SetMaxContentSize(FrameworkElement frameworkElement, Size size)
    {
        frameworkElement.MaxWidth = size.Width;
        frameworkElement.MaxHeight = size.Height;
        frameworkElement.Width = size.Width;
        frameworkElement.Height = size.Height;
    }
    public static void SetWidthAndHeight(FrameworkElement frameworkElement, Size size)
    {
        frameworkElement.Width = size.Width;
        frameworkElement.Height = size.Height;
        frameworkElement.UpdateLayout();
    }
    public static T FindName<T>(FrameworkElement element, string controlNamePrefix, int serie)
    {
        return FindName<T>(element, controlNamePrefix + serie);
    }
    static bool IsContentControl(object customControl)
    {
        if (RH.IsOrIsDeriveFromBaseClass(customControl.GetType(), typeof(ContentControl)))
        {
            var contentControl = (ContentControl)customControl;
            if (RH.IsOrIsDeriveFromBaseClass(contentControl.Content.GetType(), typeof(FrameworkElement)))
            {
                return true;
            }
        }
        return false;
    }
    static bool IsPanel(object customControl)
    {
        return RH.IsOrIsDeriveFromBaseClass(customControl.GetType(), typeof(Panel));
    }
    public static T FindByTag<T>(object customControl, object tag)
        where T : FrameworkElement
    {
        if (IsContentControl(customControl))
        {
            ContentControl contentControl = (ContentControl)customControl;
            return FindByTag<T>(contentControl.Content, tag);
        }
        else if (IsPanel(customControl))
        {
            Panel panel = (Panel)customControl;
            foreach (var item in panel.Children)
            {
                if (IsPanel(item) || IsContentControl(item))
                {
                    return FindByTag<T>(item, tag);
                }
                if (RH.IsOrIsDeriveFromBaseClass(item.GetType(), typeof(FrameworkElement)))
                {
                    FrameworkElement frameworkElement = (FrameworkElement)item;
                    if (BTS.CompareAsObjectAndString(frameworkElement.Tag, tag))
                    {
                        return (T)frameworkElement;
                    }
                }
            }
        }
        else
        {
            ThrowEx.Custom(Translate.FromKey(XlfKeys.customControlIsNotContentControlOrPanel));
        }
        return default(T);
    }
    /// <summary>
    /// Dont use Aligment for stretch / fill all available size.
    /// Width / Height = double.NaN work like a charm!
    /// </summary>
    /// <param name="grid"></param>
    public static void AligmentStretch(Grid grid)
    {
        grid.HorizontalAlignment = HorizontalAlignment.Stretch;
        grid.VerticalAlignment = VerticalAlignment.Stretch;
    }
    /// <summary>
    /// Dont use Aligment for stretch / fill all available size.
    /// Width / Height = double.NaN work like a charm!
    /// </summary>
    /// <param name="frameworkElement"></param>
    public static void HorizontalAligmentStretch(FrameworkElement frameworkElement)
    {
        frameworkElement.HorizontalAlignment = HorizontalAlignment.Stretch;
        if (frameworkElement is Control)
        {
            var control = (Control)frameworkElement;
            control.HorizontalContentAlignment = HorizontalAlignment.Stretch;
        }
    }
    /// <summary>
    /// Dont use Aligment for stretch / fill all available size.
    /// Width / Height = double.NaN work like a charm!
    /// </summary>
    /// <param name="frameworkElement"></param>
    public static void VerticalAligmentStretch(FrameworkElement frameworkElement)
    {
        frameworkElement.VerticalAlignment = VerticalAlignment.Stretch;
        if (frameworkElement is Control)
        {
            var control = (Control)frameworkElement;
            control.VerticalContentAlignment = VerticalAlignment.Stretch;
        }
    }
    public static T FindName<T>(FrameworkElement element, string controlName)
    {
        return (T)element.FindName(controlName);
    }
}
