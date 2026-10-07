#define ASYNC
namespace SunamoWpf.Controls.Helpers;

public partial class CheckBoxDataHelper
{
    public static CheckBoxData<UIElement> TextBlock(ControlInitData controlInitData)
    {
        return Get(TextBlockHelper.Get(controlInitData));
    }

    public static CheckBoxData<UIElement> CheckBox(ControlInitData controlInitData)
    {
        return Get(CheckBoxHelper.Get(controlInitData));
    }

    /// <summary>
    /// Use ActionButton() for buttons without handler
    /// </summary>
    /// <param name="controlInitData"></param>
    public static CheckBoxData<UIElement> Button(ControlInitData controlInitData)
    {
        return Get(ButtonHelper.Get(controlInitData));
    }
}