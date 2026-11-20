#define ASYNC
namespace SunamoWpf.Helpers.BaseControls;

/// <summary>
/// Represents the content control helper type.
/// </summary>
public partial class ContentControlHelper
{
    /// <summary>
    /// Cast to t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>The cast to t result.</returns>
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