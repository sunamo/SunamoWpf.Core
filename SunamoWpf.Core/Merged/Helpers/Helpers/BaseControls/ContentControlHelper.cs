#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

public partial class ContentControlHelper
{
    public static T CastTo<T>(object value) where T : class
    {
        if (value is T)
        {
            return (T)value;
        }
        var contentControl = (ContentControl)value;
        return contentControl.Content as T;

    }

    
}