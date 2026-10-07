#define ASYNC
namespace SunamoWpf.Controls.Helpers;

public partial class CheckBoxDataHelper
{
    private static CheckBoxData<UIElement> Get(UIElement element)
    {
        var result = new CheckBoxData<UIElement>();
        result.t = element;
        return result;
    }
    public static CheckBoxData<UIElement> ActionButton(ControlInitData controlInitData)
    {
        return Get(ActionButtonHelper.Get<string>(controlInitData));
    }
    public static CheckBoxData<UIElement> TextBox(ControlInitData controlInitData)
    {
        return Get(TextBoxHelper.Get(controlInitData));
    }
}