#define ASYNC
namespace SunamoWpf.Controls;

public partial class ResourceDictionaryStyles
{
    #region 10 for remembering default size
    /// <summary>
    /// Margin 10.
    /// </summary>
    /// <param name="controls">The controls.</param>
    public static void Margin10(IList<SunamoPasswordBox> controls)
    {
        Margin(def, controls);
    }
    #endregion

    /// <summary>
    /// Margin.
    /// </summary>
    /// <param name="margin">The margin.</param>
    /// <param name="controls">The controls.</param>
    public static void Margin(double margin, IList<SunamoPasswordBox> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }
}