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
    /// <summary>
    /// Action button.
    /// </summary>
    /// <param name="controlInitData">The control init data.</param>
    /// <returns>The action button result.</returns>
    public static CheckBoxData<UIElement> ActionButton(ControlInitData controlInitData)
    {
        return Get(ActionButtonHelper.Get<string>(controlInitData));
    }
    /// <summary>
    /// Text box.
    /// </summary>
    /// <param name="controlInitData">The control init data.</param>
    /// <returns>The text box result.</returns>
    public static CheckBoxData<UIElement> TextBox(ControlInitData controlInitData)
    {
        return Get(TextBoxHelper.Get(controlInitData));
    }
}