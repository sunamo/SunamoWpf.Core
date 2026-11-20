#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

/// <summary>
/// Represents the framework element helper type.
/// </summary>
public partial class FrameworkElementHelper
{
    static Type type = typeof(FrameworkElementHelper);
    /// <summary>
    /// Get tag check box list UC.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <returns>The get tag check box list UC result.</returns>
    public static object GetTagCheckBoxListUC(object sender)
    {
        var frameworkElement = (FrameworkElement)sender;
        var tag = frameworkElement.Tag;
        var elementTag = (FrameworkElementTag)tag;
        return elementTag.tagCheckBoxListUC;
    }
    /// <summary>
    /// Count of ancestor.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The count of ancestor result.</returns>
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
    /// <summary>
    /// Cast to t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <returns>The cast to t result.</returns>
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
    /// <summary>
    /// Get max content size.
    /// </summary>
    /// <param name="frameworkElement">The framework element.</param>
    /// <returns>The get max content size result.</returns>
    public static Size GetMaxContentSize(FrameworkElement frameworkElement)
    {
        return new Size(frameworkElement.ActualWidth, frameworkElement.ActualHeight);
    }
    /// <summary>
    /// Get content size.
    /// </summary>
    /// <param name="frameworkElement">The framework element.</param>
    /// <returns>The get content size result.</returns>
    public static Size GetContentSize(FrameworkElement frameworkElement)
    {
        return new Size(frameworkElement.Width, frameworkElement.Height);
    }
    /// <summary>
    /// Set max content size.
    /// </summary>
    /// <param name="frameworkElement">The framework element.</param>
    /// <param name="size">The size.</param>
    public static void SetMaxContentSize(FrameworkElement frameworkElement, Size size)
    {
        frameworkElement.MaxWidth = size.Width;
        frameworkElement.MaxHeight = size.Height;
        frameworkElement.Width = size.Width;
        frameworkElement.Height = size.Height;
    }
    /// <summary>
    /// Set width and height.
    /// </summary>
    /// <param name="frameworkElement">The framework element.</param>
    /// <param name="size">The size.</param>
    public static void SetWidthAndHeight(FrameworkElement frameworkElement, Size size)
    {
        frameworkElement.Width = size.Width;
        frameworkElement.Height = size.Height;
        frameworkElement.UpdateLayout();
    }
    /// <summary>
    /// Find name t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <param name="controlNamePrefix">The control name prefix.</param>
    /// <param name="serie">The serie.</param>
    /// <returns>The find name t result.</returns>
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
    /// <summary>
    /// Find by tag t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="customControl">The custom control.</param>
    /// <param name="tag">The tag.</param>
    /// <returns>The find by tag t result.</returns>
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
            ThrowEx.Custom("Custom control is not content control or panel");
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
    /// <summary>
    /// Find name t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <param name="controlName">The control name.</param>
    /// <returns>The find name t result.</returns>
    public static T FindName<T>(FrameworkElement element, string controlName)
    {
        return (T)element.FindName(controlName);
    }
}
