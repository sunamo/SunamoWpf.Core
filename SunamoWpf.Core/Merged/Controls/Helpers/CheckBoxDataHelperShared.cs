#define ASYNC
namespace SunamoWpf.Controls.Helpers;

public partial class CheckBoxDataHelper
{
    private static CheckBoxData<UIElement> Get(UIElement c)
    {
        var vr = new CheckBoxData<UIElement>();
        vr.t = c;
        return vr;
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