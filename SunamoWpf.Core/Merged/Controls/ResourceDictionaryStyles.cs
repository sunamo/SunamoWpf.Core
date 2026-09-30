#define ASYNC
namespace SunamoWpf.Controls;

public partial class ResourceDictionaryStyles
{
    #region 10 for remembering default size
    public static void Margin10(IList<SunamoPasswordBox> p)
    {
        Margin(def, p);
    }
    #endregion

    public static void Margin(double d, IList<SunamoPasswordBox> p)
    {
        foreach (var item in p)
        {
            item.Margin = new Thickness(d);
        }
    }
}