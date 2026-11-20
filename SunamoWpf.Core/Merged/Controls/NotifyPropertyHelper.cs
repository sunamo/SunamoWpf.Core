#define ASYNC
namespace SunamoWpf.Controls;

/// <summary>
/// Represents the notify property helper type.
/// </summary>
public class NotifyPropertyHelper
{
    /// <summary>
    /// Inner objects of notify property changed wrapper t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="wrappers">The wrappers.</param>
    /// <returns>The inner objects of notify property changed wrapper t result.</returns>
    public static List<T> InnerObjectsOfNotifyPropertyChangedWrapper<T>(IList<NotifyPropertyChangedWrapper<T>> wrappers) where T : DependencyObject
    {
        List<T> result = new List<T>(wrappers.Count);

        foreach (var item in wrappers)
        {
            result.Add(item.o);
        }

        return result;
    }

    /// <summary>
    /// Check box t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="notifyWrapper">The notify wrapper.</param>
    public static void CheckBox<T>(NotifyPropertyChangedWrapper<T> notifyWrapper) where T : DependencyObject
    {
        notifyWrapper.dpIsChecked = ToggleButton.IsCheckedProperty;
        notifyWrapper.dpContent = ContentControl.ContentProperty;
        notifyWrapper.dpTag = FrameworkElement.TagProperty;
        notifyWrapper.dpVisibility = FrameworkElement.VisibilityProperty;
        notifyWrapper.dpHeight = FrameworkElement.HeightProperty;
    }
}