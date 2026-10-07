#define ASYNC
namespace SunamoWpf.Controls;

public partial class ResourceDictionaryStyles
{
    #region 10 for remembering default size
    public static void Margin10(IList<SunamoPasswordBox> controls)
    {
        Margin(def, controls);
    }
    #endregion

    public static void Margin(double margin, IList<SunamoPasswordBox> controls)
    {
        foreach (var item in controls)
        {
            item.Margin = new Thickness(margin);
        }
    }
}