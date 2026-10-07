#define ASYNC
namespace SunamoWpf.Controls;

public class NotifyPropertyHelper
{
    public static List<T> InnerObjectsOfNotifyPropertyChangedWrapper<T>(IList<NotifyPropertyChangedWrapper<T>> wrappers) where T : DependencyObject
    {
        List<T> result = new List<T>(wrappers.Count);

        foreach (var item in wrappers)
        {
            result.Add(item.o);
        }

        return result;
    }

    public static void CheckBox<T>(NotifyPropertyChangedWrapper<T> notifyWrapper) where T : DependencyObject
    {
        notifyWrapper.dpIsChecked = ToggleButton.IsCheckedProperty;
        notifyWrapper.dpContent = ContentControl.ContentProperty;
        notifyWrapper.dpTag = FrameworkElement.TagProperty;
        notifyWrapper.dpVisibility = FrameworkElement.VisibilityProperty;
        notifyWrapper.dpHeight = FrameworkElement.HeightProperty;
    }
}